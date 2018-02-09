using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Sawanna
{
    class MakeAnimals
    {
        private List<Antelope> manyAntylopes = new List<Antelope>();
        private List<Lion> manyLions = new List<Lion>();

        private int numbersOfLions = 5;

        public int numbersOfAntelopes { private set; get; }
        public int IdAnimalCouter { private set; get; }
        /// <summary>
        /// Tworzy wszystkie zwierzaki.
        /// </summary>
        public MakeAnimals()
        {
            numbersOfAntelopes = 20;
            Antelopes();
            Lions();
        }

        public List<Antelope> Antelopes()
        {
            Random r = new Random();
            for (int i = 0; i < this.numbersOfAntelopes; i++)
            {
                manyAntylopes.Add(new Antelope(this.IdAnimalCouter));
                manyAntylopes[i].animalRectangle.X = r.Next(1, Screen.PrimaryScreen.WorkingArea.Width);
                manyAntylopes[i].animalRectangle.Y = r.Next(1, Screen.PrimaryScreen.WorkingArea.Height);
                IdAnimalCouter++;
            }
            return manyAntylopes;
        }

        public List<Lion> Lions()
        {
            Random r = new Random();
            for (int i = 0; i < this.numbersOfLions; i++)
            {
                manyLions.Add(new Lion(this.IdAnimalCouter));
                manyLions[i].animalRectangle.X = r.Next(1, Screen.PrimaryScreen.WorkingArea.Width);
                manyLions[i].animalRectangle.Y = r.Next(1, Screen.PrimaryScreen.WorkingArea.Height);
                IdAnimalCouter++;
            }
            return manyLions;
        }

        public List<Antelope> GetAntelopeList()
        {
            return manyAntylopes;
        }

        public List<Lion> GetLionsList()
        {
            return manyLions;
        }
    }
}
