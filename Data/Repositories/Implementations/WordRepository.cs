using Data.Entities;

namespace Data.Repositories.Implementations;
public class WordRepository : BaseRepository<WordRecord>, IWordRepository
{
    public WordRepository(DictionaryDbContext context) : base(context)
    {
    }
}