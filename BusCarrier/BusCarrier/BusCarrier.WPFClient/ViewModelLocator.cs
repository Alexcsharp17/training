using BusCarrier.WPFClient.ViewModels;

namespace BusCarrier.WPFClient
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel { get; private set; }

        public void SetUp(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }
    }
}
