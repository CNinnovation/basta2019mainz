namespace GenericViewModels.Services
{
    public interface IItemToViewModelMap<T, TViewModel>
        where TViewModel : class
        where T : class
    {
        void Add(T item, TViewModel viewModel);
        TViewModel? GetViewModel(T? item);
        void Reset();
    }
}