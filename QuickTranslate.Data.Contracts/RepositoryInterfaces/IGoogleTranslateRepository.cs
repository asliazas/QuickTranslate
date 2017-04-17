using QuickTranslate.Entities;

namespace QuickTranslate.Data.Contracts.RepositoryInterfaces
{
    public interface IGoogleTranslateRepository
    {
        Translation Translate(string text, string to, string from = null);
    }
}
