using Xenko.Engine;
using Xenko.UI.Controls;

namespace SupercarsDream
{
    public class Makes : SyncScript
    {
        public Entity backButton;

        public UILibrary UILibrary { get; set; }

        public static string globalMake;

        public readonly string[] makes = {
  "adi",
  "akura",
  "alfa",
  "aston",
  "bentle",
  "bmv",
  "bugati",
  "cadilac",
  "chonda",
  "citron",
  "dodg",
  "ferari",
  "fort",
  "henesey",
  "hevrolet",
  "holdem",
  "hrysler",
  "jagur",
  "konigseg",
  "lambo",
  "lotuz",
  "luxus",
  "maklaren",
  "masda",
  "maybah",
  "mazerati",
  "merc",
  "mitsushi",
  "nisan",
  "opl",
  "other",
  "pahani",
  "pegot",
  "pontiak",
  "porshe",
  "reno",
  "rols_roys",
  "rufe",
  "sab",
  "salen",
  "shelbi",
  "tezla",
  "tojota",
  "twr",
  "vendeta",
  "vw",
  "zenwo",
  "zubaru"
    };

        // Start is called before the first frame update
        public override void Start()
        {
            foreach (string make in makes)
            {
                var button = UILibrary.InstantiateElement<Button>("");

                TextBlock tb = (TextBlock)button.Content;

                tb.Text = make;

                button.Click += delegate
                {
                    //  var scenesComponent = scenes.GetComponent<Scenes>();
                    //  globalMake = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
                    // scenesComponent.ChangeToModels();
                };
            }
        }

        // Update is called once per frame
        public override void Update()
        {
        }
    }
}