using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MesssagingCenter
{
    public class AddColorsPageModel : FreshBasePageModel
    {
     public ICommand AddColorsCommand { get; set; }
     public string ColorName { get; set; }

     public AddColorsPageModel()
        {
            AddColorsCommand = new Command(async () =>
               await OnAddColors());
        }

     private async Task OnAddColors()
        {
            CustomColor color = new CustomColor();
            color.ColorId = DateTime.Today.Ticks.ToString();
            color.ColorName = ColorName;

            MessagingCenter.Send<AddColorsPageModel,
                  CustomColor>(this, "ColorUpdate", color);
            await CoreMethods.PopToRoot(false);
        }
    }
}
