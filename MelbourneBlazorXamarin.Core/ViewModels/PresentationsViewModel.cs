using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MelbourneBlazorXamarin.Core.Models;
using MelbourneBlazorXamarin.Core.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace MelbourneBlazorXamarin.Core.ViewModels
{
    public class PresentationsViewModel : MvvmHelpers.BaseViewModel
    {
        public ObservableRangeCollection<Presentation> Presentations = new ObservableRangeCollection<Presentation>();
        public ICommand LoadItemsCommand => new AsyncCommand<string>(LoadItemsAsync);

        public PresentationDataStore DataStore = new PresentationDataStore();
        public PresentationsViewModel()
        {
            Title = "Presentations";
        }


        String PresenterId;
        public PresentationsViewModel(string presenterId)
        {
            Title = "Presenters";
            PresenterId = presenterId;
        }

        public async Task LoadItemsAsync(string presenterId)
        {
            try
            {
                await Task.Delay(500);//These are needed or the list is blank, investigate further and/or report bug
                Presentations.Clear();
                var items = await DataStore.GetItemsAsync(true);
                await Task.Delay(500);
                presenterId = string.IsNullOrWhiteSpace(presenterId) ? PresenterId : presenterId;

                if (presenterId != null)
                    items = items.Where(x => x.PresenterId == presenterId);


                Presentations.AddRange(items);
                OnPropertyChanged(nameof(Presentations));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}