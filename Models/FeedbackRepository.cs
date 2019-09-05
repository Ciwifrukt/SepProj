using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    /*
     Vi är fina i kanten och låter FeedbackRepository implementer IFeedbackRepository

     Det ger i nuläget ingen vinst men öppnar upp möjligheten att i framtid att lätt byta ut sättet att spara feedbacks.

     T.ex om vi vill spara feedbacks i en annan sorts databas (t.ex MySQL) eller i en textfil
     ...eller mer troligt: att vi vill "fake'a" repositoryt och spara feedback'en i minnet (i en variabel)
     Då kan vi skapa ett enhetstest (unit test) som testar olika delar av din applikation utan att du behöver skriva saker i databasen (vilket tar tid och kan skapa sidoeffekter)
    */
    public class FeedbackRepository: IFeedbackRepository
    {
        private readonly AppDbContext _appDbContext;

        public FeedbackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddFeedback(Feedback feedback)
        {
            _appDbContext.Feedbacks.Add(feedback);
            _appDbContext.SaveChanges();
        }
    }
}
