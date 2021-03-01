using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface IQuestions
    {
        IEnumerable<Questions> GetQuestions();
        Questions GetQuestionById(int? id);
        void RemoveQuestion(Questions question);
        void AddQuestion(Questions question);
        void EditQuestion(Questions question);
    }
}
