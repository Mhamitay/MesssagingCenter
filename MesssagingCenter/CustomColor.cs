using FreshMvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace MesssagingCenter
{
    public class CustomColor
    {
        public string ColorId { get; set; }
        public string ColorName { get; set; }
    }

    public class SampleAppPageModel : FreshBasePageModel,INotifyPropertyChanged
    {
        public ICommand GoToColorsCommand { get; set; }
        ObservableCollection<CustomColor> _colorsList;
        public event PropertyChangedEventHandler PropertyChanged;
       
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<CustomColor> ColorsList
        {
            get { return _colorsList; }
            set
            {
                _colorsList = value;
            }
        }

        public SampleAppPageModel()
        {
            GoToColorsCommand = new Command(async () => await
               OnNavigateDetailPage());
        }
        private async Task OnNavigateDetailPage()
        {
            await CoreMethods.PushPageModel<AddColorsPageModel>();
        }
        public override void Init(object initData)
        {
            ColorsList = new ObservableCollection<CustomColor>();

            ColorsList.Add(new CustomColor
            {
                ColorId = "1",
                ColorName = "Red"
            });
            ColorsList.Add(new CustomColor
            {
                ColorId = "2",
                ColorName = "Green"
            });
            ColorsList.Add(new CustomColor
            {
                ColorId = "3",
                ColorName = "Blue"
            });




            MessagingCenter.Subscribe<AddColorsPageModel,
                  CustomColor>(this, "ColorUpdate",
                     (page, updateColor) => {

                         if (updateColor != null)
                         {
                             ColorsList.Add(updateColor);

                         }
                     });
        }
    }
}
