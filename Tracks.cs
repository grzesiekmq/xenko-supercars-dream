using Xenko.Engine;
using Xenko.UI.Controls;

namespace SupercarsDream
{
    public class Tracks : SyncScript
    {
        public Entity backButton;

        public UILibrary UILibrary { get; set; }

        private readonly string[] tracks = {
    "Barcelona",
     "Bathurst",
     "Brands-Hatch",
// 'Circuit de la Sarthe',
     "Hungaroring",
     "Indianapolis",
     "Interlagos",
     "Isle-of-Man",
     "Kyalami",
     "Laguna-Seca",
     "Le-Mans",
     "Magny-Cours",
     "Monaco",
     "Montreal",
     "Monza",
     "Nurburgring",
     "Red-Bull-Ring",
     "Silverstone",
     "Spa-Francorchamps",
     "Suzuka",
     "Zandvoort"
    };

        // Start is called before the first frame update
        public override void Start()
        {
            foreach (string track in tracks)
            {
                var button = UILibrary.InstantiateElement<Button>("");

                TextBlock tb = (TextBlock)button.Content;

                tb.Text = track;

                button.Click += delegate
                {
                    //  var scenesComponent = scenes.GetComponent<Scenes>();
                    //   scenesComponent.ChangeToMenu();
                };
            }

            //    var backBtnComponent = backButton.Get<Button>();
            //  backBtnComponent.Click += delegate {
            //    var scenesComponent = scenes.GetComponent<Scenes>();
            //  scenesComponent.ChangeToMakes();

            // };
        }

        // Update is called once per frame
        public override void Update()
        {
        }
    }
}