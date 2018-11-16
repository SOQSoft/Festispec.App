using Festispec.ClientApi;
using Festispec.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.Tests.ClientApi
{
    [TestFixture]
    class FormCrudTest
    {
        private readonly FormsClient formsClient;
        public FormCrudTest()
        {
            formsClient = new FormsClient("http://localhost:5000");
        }
        [Test]
        public void CreateForm()
        {
            int id = 20;
            int qid = 20;
            Form form = new Form
            {
                Id = id++,
                Name = "pure aids"
            };
            form.Question.Add(new Question()
            {
                Id = qid++,
                FormId = form.Id,
                Description = "lolxd1",
                Text = "Wanneer kwamen koeien",
                QuestionType = 0, // TODO: Adding enums back;
            });
            form.Question.Add(new Question()
            {
                Id = qid++,
                FormId = form.Id,
                Description = "lolxd2",
                Text = "Wanneer kwamen koeie2n2",
                QuestionType = 0, // TODO: Adding enums back;
            });
            form.Question.Add(new Question()
            {
                Id = qid++,
                FormId = form.Id,
                Description = "lolxd2",
                Text = "Wanneer kwamen koeie2n2",
                QuestionType = QuestionType.Multiplechoice,
                QuestionItem = new List<QuestionItem>()
                {
                    new QuestionItem()
                    {
                        Body = "OOF"
                    }
                }
            });
            
            var ans = formsClient.PostFormAsync(form);
            ans.Wait();
            Assert.IsTrue(true);
        }
    }
}
