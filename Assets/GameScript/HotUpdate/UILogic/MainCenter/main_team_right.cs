using FairyGUI;

namespace MainCenter
{
    public partial class main_team_right : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            this._teamList.itemRenderer = OnRendererTeamList;
            this._teamList.numItems = 2;
        }

        private void OnRendererTeamList(int index, GObject item)
        {
        }


        public void SetData()
        {
        }
    }
}
