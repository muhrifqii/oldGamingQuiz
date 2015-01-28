using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OldGamingQuiz.Helper
{
    public class FlipTileTemplate
    {
        IOHelper iso = new IOHelper();


        public void SFlipTileTemplate()
        {
            Profile profil = JsonConvert.DeserializeObject<Profile>(iso.Read("profile.json"));
            //ShellTile oTile = ShellTile.ActiveTiles.First();
            ShellTile oTile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("flip".ToString()));

            if (oTile != null && oTile.NavigationUri.ToString().Contains("flip"))
            {
                FlipTileData oFliptile = new FlipTileData();
                oFliptile.Title = "Old Gaming Quiz";
                oFliptile.Count = profil.SolvedCount;
                oFliptile.BackTitle = profil.SolvedCount.ToString() + " ScreenShot Solved";
                //oFliptile.BackContent = (30 - profil.solvedQuestion).ToString() + " Surah remaining";

                oFliptile.BackContent = profil.SolvedCount.ToString() + " ScreenShot Solved";
                oFliptile.WideBackContent = profil.SolvedCount.ToString() + " ScreenShot Solved";

                oFliptile.SmallBackgroundImage = new Uri("/Assets/Tiles/159.png", UriKind.Relative);
                oFliptile.BackgroundImage = new Uri("/Assets/Tiles/336.png", UriKind.Relative);
                oFliptile.WideBackgroundImage = new Uri("/Assets/Tiles/691.png", UriKind.Relative);

                oFliptile.BackBackgroundImage = new Uri("/Assets/Tiles/336Back.png", UriKind.Relative);
                oFliptile.WideBackBackgroundImage = new Uri("/Assets/Tiles/691Back.png", UriKind.Relative);
                oTile.Update(oFliptile);
            }
            else
            {
                //once it is created flip tile
                MessageBox.Show("Tile Successfully Created");
                Uri tileUri = new Uri("/MainPage.xaml?tile=flip", UriKind.Relative);
                ShellTileData tileData = this.CreateFlipTileData();
                ShellTile.Create(tileUri, tileData, true);
            }
        }

        private ShellTileData CreateFlipTileData()
        {
            Profile profil = JsonConvert.DeserializeObject<Profile>(iso.Read("profile.json"));
            return new FlipTileData()
            {
                Title = "Old Gaming Quiz",
                BackTitle = profil.SolvedCount.ToString() + " ScreenShot Solved",
                BackContent = profil.SolvedCount.ToString() + " ScreenShot Solved",
                WideBackContent = profil.SolvedCount.ToString() + " ScreenShot Solved",
                Count = profil.SolvedCount,
                SmallBackgroundImage = new Uri("/Assets/Tiles/159.png", UriKind.Relative),
                BackgroundImage = new Uri("/Assets/Tiles/336.png", UriKind.Relative),
                WideBackgroundImage = new Uri("/Assets/Tiles/691.png", UriKind.Relative),
                BackBackgroundImage = new Uri("/Assets/Tiles/336Back.png", UriKind.Relative),
                WideBackBackgroundImage = new Uri("/Assets/Tiles/691Back.png", UriKind.Relative)
            };
        }
    }
}
