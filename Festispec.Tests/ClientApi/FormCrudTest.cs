using Festispec.ApiClient;

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
            formsClient = new FormsClient("https://localhost:5001");
        }
        [Test]
        public void CreateForm()
        {
            Form form = new Form
            {
                Name = "pure aids"
            };
            form.Question.Add(new Question()
            {
                FormId = form.Id,
                Description = "lolxd1",
                Text = "Wanneer kwamen koeien",
                QuestionType = 0, // TODO: Adding enums back;
            });
            form.Question.Add(new Question()
            {
                FormId = form.Id,
                Description = "lolxd2",
                Text = "Wanneer kwamen koeie2n2",
                QuestionType = 0, // TODO: Adding enums back;
            });
            form.Question.Add(new Question()
            {
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
