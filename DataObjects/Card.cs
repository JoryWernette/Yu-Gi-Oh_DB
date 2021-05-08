using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Card
    {
        public string CardID { get; set; }

        [Display(Name = "Name")]
        public string CardName { get; set; }
        public string CardCategory { get; set; }
        public string CardType { get; set; }

        [Display(Name = "Type")]
        public string MonsterType { get; set; }
        public string MonsterSubType { get; set; }

        [Display(Name = "Attribute")]
        public string MonsterAttribute { get; set; }

        [Display(Name = "Lvl/Rank")]
        public int LevelRank { get; set; }

        [Display(Name = "Atk")]
        public int Attack { get; set; }

        [Display(Name = "Def")]
        public int Defense { get; set; }

        [Display(Name = "Scale")]
        public int PendulumScale { get; set; }

        [Display(Name = "Link")]
        public int LinkNumber { get; set; }

        [Display(Name = "Banned")]
        public string BanlistPlacement { get; set; }
        public string CardText { get; set; }
        public bool Active { get; set; }
    }
}
