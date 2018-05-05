using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccess
{
    public class Repository
    {
        TestContext _context = new TestContext();

        public void AddSentence(string sentence, int count)
        {
            _context.Sentences.Add(new SentenceEntity
            {
                ReversedSentence = sentence,
                Count = count
            });

            _context.SaveChanges();
        }

        public List<SentenceEntity> GetAllSentences()
        {
            return _context.Sentences.ToList();
        }
    }
}
