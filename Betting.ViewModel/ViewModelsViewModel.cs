using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reactive;
using System.Windows.Input;

namespace Betting.ViewModel
{
    public class ViewModelsViewModel : ReactiveObject
    {
        private readonly ReactiveCommand<Unit, Unit> forceGcCommand;
        private Lazy<KeyValuePair<string, KeyValuePair<string, object>>[]> types;
        private object selectedItem;

        public ViewModelsViewModel(string viewModelAssembly)
        {
            types = new Lazy<KeyValuePair<string, KeyValuePair<string, object>>[]>
                (() =>
                {
                    try
                    {
                        return ViewModelFinder.Select(viewModelAssembly);

                    }
                    catch (Exception ex)
                    {

                    }
                    return new KeyValuePair<string, KeyValuePair<string, object>>[0];
                });

            forceGcCommand = ReactiveCommand.Create(
                () =>
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                });
        }

        public IEnumerable Collection => types.Value;

        public ICommand ForceGCCommand => forceGcCommand;

        public object SelectedItem { get => selectedItem; set => this.RaiseAndSetIfChanged(ref selectedItem, value); }


    }
}
