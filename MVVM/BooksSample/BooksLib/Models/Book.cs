
using GenericViewModels.MVVM;

namespace BooksLib.Models
{
    public class Book : BindableBase
    {
        public int BookId { get; set; }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _publisher = string.Empty;
        public string Publisher
        {
            get => _publisher;
            set => SetProperty(ref _publisher, value);
        }

        public override string ToString() => Title;
    }
}
