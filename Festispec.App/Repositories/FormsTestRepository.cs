using Festispec.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.App.Repositories
{
    public class FormsTestRepository : IFormsRepository
    {
        private static List<Form> Forms { get; set; } = new List<Form>();
        private static bool init = false;
        public FormsTestRepository()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            if (init)
                return;
            init = true;

            int id = 0;
            int qid = 0;

            Form form = new Form();
            form.Id = id++;
            form.Name = "pure aids";
            form.Questions.Add(new Question()
            {
                Id = qid++,
                FormId = form.Id,
                Description = "lolxd1",
                Text = "Wanneer kwamen koeien",
                QuestionType = 0, // TODO: Adding enums back;
            });
            form.Questions.Add(new Question()
            {
                Id = qid++,
                FormId = form.Id,
                Description = "lolxd2",
                Text = "Wanneer kwamen koeie2n2",
                QuestionType = 0, // TODO: Adding enums back;
            });
            form.Questions.Add(new Question()
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

            Forms.Add(form);


            form = new Form();
            form.Id = id++;
            form.Name = "Festival jantje";
            form.Questions.Add(new Question()
            {
                Id = qid++,
                FormId = form.Id,
                Form = form,
                Description = "lolxd",
                Text = "Wanneer kwamen koeien",
                QuestionType = 0, // TODO: Adding enums back;
            });
            Forms.Add(form);


            form = new Form();
            form.Id = id++;
            form.Name = "Template Pieter";
            form.IsTemplate = true;
            form.Questions.Add(new Question()
            {
                Id = qid++,
                FormId = form.Id,
                Form = form,
                Description = "lolxd",
                Text = "Wanneer kwamen koeien",
                QuestionType = 0, // TODO: Adding enums back;
            });
            Forms.Add(form);
        }


        public void Add(Form form)
        {
            Forms.Add(form);
        }

        public void Update(Form form)
        {
            var f = Forms.FirstOrDefault(o => o.Id == form.Id);
            f = form;
        }

        public void Delete(Form form)
        {
            Forms.RemoveAll(o => o.Id == form.Id);
        }

        public ICollection<Form> GetAll()
        {
            return Forms;
        }
    }
}
