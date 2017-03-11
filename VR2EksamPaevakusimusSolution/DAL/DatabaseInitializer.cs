using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Questions.Add(new Models.Question
            {
                Title = "Küsimus nr 1",
                Description = "See on üks esimesi küsimusi, hurraa",
                Published = false,
                Visible = true,
            });

            context.SaveChanges();

            context.QuestionAnswers.Add(new Models.QuestionAnswer
            {
                QuestionId = context.Questions.First().QuestionId,
                Title = "Vastus 1"
            });

            context.QuestionAnswers.Add(new Models.QuestionAnswer
            {
                QuestionId = context.Questions.First().QuestionId,
                Title = "Vastus 2"
            });

            context.QuestionAnswers.Add(new Models.QuestionAnswer
            {
                QuestionId = context.Questions.First().QuestionId,
                Title = "Vastus 3"
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
