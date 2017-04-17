using System.CodeDom.Compiler;
using GalaSoft.MvvmLight;
using QuickTranslate.App.Model;
using System.Collections.ObjectModel;
using System.Linq;
using QuickTranslate.Data.Contracts.RepositoryInterfaces;
using GalaSoft.MvvmLight.Command;

namespace QuickTranslate.App.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IGoogleTranslateRepository _googleTranslateRepository;

        public ObservableCollection<Language> FromLanguages { get; set; }
        public ObservableCollection<Language> ToLanguages { get; set; }

        public Language _selectedFromLanguage { get; set; }
        public Language SelectedFromLanguage
        {
            get { return _selectedFromLanguage; }
            set
            {
                _selectedFromLanguage = value;
                RaisePropertyChanged("SelectedFromLanguage");
                RaisePropertyChanged("CanSwap");
            }
        }

        public Language _selectedToLanguage { get; set; }
        public Language SelectedToLanguage
        {
            get { return _selectedToLanguage; }
            set
            {
                _selectedToLanguage = value;
                RaisePropertyChanged("SelectedToLanguage");
                RaisePropertyChanged("CanSwap");
            }
        }

        public bool CanSwap
        {
            get { return !string.IsNullOrEmpty(SelectedFromLanguage.Code); }
        }

        RelayCommand _translateCommand;
        public RelayCommand TranslateCommand
        {
            get
            {
                if (_translateCommand == null)
                {
                    _translateCommand = new RelayCommand(() =>
                    {
                        Translate();
                    });
                }
                return _translateCommand;
            }
        }

        RelayCommand _swapCommand;
        public RelayCommand SwapCommand
        {
            get
            {
                if (_swapCommand == null)
                {
                    _swapCommand = new RelayCommand(() =>
                    {
                        Swap();
                    });
                }
                return _swapCommand;
            }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RaisePropertyChanged("Text");
            }
        }

        private string _translatedText;
        public string TranslatedText
        {
            get { return _translatedText; }
            set
            {
                _translatedText = value;
                RaisePropertyChanged("TranslatedText");
            }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IGoogleTranslateRepository googleTranslateRepository)
        {
            _googleTranslateRepository = googleTranslateRepository;
            var languages = new ObservableCollection<Language>
            {
                #region languages
                new Language() { Code = "af", Name = "Afrikaans"},
                new Language() { Code = "sq", Name = "Albanian"},
                new Language() { Code = "ar", Name = "Arabic"},
                new Language() { Code = "az", Name = "Azerbaijani"},
                new Language() { Code = "eu", Name = "Basque"},
                new Language() { Code = "bn", Name = "Bengali"},
                new Language() { Code = "be", Name = "Belarusian"},
                new Language() { Code = "bg", Name = "Bulgarian"},
                new Language() { Code = "ca", Name = "Catalan"},
                new Language() { Code = "zh-CN", Name = "Chinese Simplified"},
                new Language() { Code = "zh-TW", Name = "Chinese Traditional"},
                new Language() { Code = "hr", Name = "Croatian"},
                new Language() { Code = "cs", Name = "Czech"},
                new Language() { Code = "da", Name = "Danish"},
                new Language() { Code = "nl", Name = "Dutch"},
                new Language() { Code = "en", Name = "English"},
                new Language() { Code = "eo", Name = "Esperanto"},
                new Language() { Code = "et", Name = "Estonian"},
                new Language() { Code = "tl", Name = "Filipino"},
                new Language() { Code = "fi", Name = "Finnish"},
                new Language() { Code = "fr", Name = "French"},
                new Language() { Code = "gl", Name = "Galician"},
                new Language() { Code = "ka", Name = "Georgian"},
                new Language() { Code = "de", Name = "German"},
                new Language() { Code = "el", Name = "Greek"},
                new Language() { Code = "gu", Name = "Gujarati"},
                new Language() { Code = "ht", Name = "Haitian Creole"},
                new Language() { Code = "iw", Name = "Hebrew"},
                new Language() { Code = "hi", Name = "Hindi"},
                new Language() { Code = "hu", Name = "Hungarian"},
                new Language() { Code = "is", Name = "Icelandic"},
                new Language() { Code = "id", Name = "Indonesian"},
                new Language() { Code = "ga", Name = "Irish"},
                new Language() { Code = "it", Name = "Italian"},
                new Language() { Code = "ja", Name = "Japanese"},
                new Language() { Code = "kn", Name = "Kannada"},
                new Language() { Code = "ko", Name = "Korean"},
                new Language() { Code = "la", Name = "Latin"},
                new Language() { Code = "lv", Name = "Latvian"},
                new Language() { Code = "lt", Name = "Lithuanian"},
                new Language() { Code = "mk", Name = "Macedonian"},
                new Language() { Code = "ms", Name = "Malay"},
                new Language() { Code = "mt", Name = "Maltese"},
                new Language() { Code = "no", Name = "Norwegian"},
                new Language() { Code = "fa", Name = "Persian"},
                new Language() { Code = "pl", Name = "Polish"},
                new Language() { Code = "pt", Name = "Portuguese"},
                new Language() { Code = "ro", Name = "Romanian"},
                new Language() { Code = "ru", Name = "Russian"},
                new Language() { Code = "sr", Name = "Serbian"},
                new Language() { Code = "sk", Name = "Slovak"},
                new Language() { Code = "sl", Name = "Slovenian"},
                new Language() { Code = "es", Name = "Spanish"},
                new Language() { Code = "sw", Name = "Swahili"},
                new Language() { Code = "sv", Name = "Swedish"},
                new Language() { Code = "ta", Name = "Tamil"},
                new Language() { Code = "te", Name = "Telugu"},
                new Language() { Code = "th", Name = "Thai"},
                new Language() { Code = "tr", Name = "Turkish"},
                new Language() { Code = "uk", Name = "Ukrainian"},
                new Language() { Code = "ur", Name = "Urdu"},
                new Language() { Code = "vi", Name = "Vietnamese"},
                new Language() { Code = "cy", Name = "Welsh"},
                new Language() { Code = "yi", Name = "Yiddish"}
                #endregion
            };

            FromLanguages = new ObservableCollection<Language>();
            ToLanguages = new ObservableCollection<Language>();

            FromLanguages.Add(new Language()
            {
                Code = null,
                Name = "Detect Language"
            });
            foreach (var language in languages)
            {
                FromLanguages.Add(language);
                ToLanguages.Add(language);
            }

            SelectedFromLanguage = FromLanguages.First();
            SelectedToLanguage = ToLanguages.FirstOrDefault(l => l.Code == "en");
        }

        public void Translate()
        {
            var translation = _googleTranslateRepository.Translate(Text, SelectedToLanguage.Code,
                SelectedFromLanguage?.Code);

            TranslatedText = translation.TranslatedText;
            SelectedFromLanguage = FromLanguages.FirstOrDefault(l => l.Code == translation.From);
        }

        public void Swap()
        {
            var temp = SelectedToLanguage;
            SelectedToLanguage = SelectedFromLanguage;
            SelectedFromLanguage = temp;
        }
    }
}