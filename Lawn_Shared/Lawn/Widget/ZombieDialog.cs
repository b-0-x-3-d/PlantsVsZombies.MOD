using System;
using Sexy;

namespace Lawn
{
    internal class ZombieDialog : LawnDialog, EditListener
    {
        public ZombieDialog(LawnApp theApp) : base(theApp, null, 36, true, "CHEAT", "Zombie ID to spawn:", "", 2)
        {
            mApp = theApp;
            mVerticalCenterText = false;
            mLevelEditWidget = LawnCommon.CreateEditWidget(0, this, this, "Cheat", "");
            mLevelEditWidget.mMaxChars = 12;
            mLevelEditWidget.SetFont(Resources.FONT_BRIANNETOD12);
            string text = string.Empty;
            if (mApp.mGameMode != GameMode.Adventure)
            {
                text = "";
            }
            else if (mApp.HasFinishedAdventure())
            {
                int level = theApp.mPlayerInfo.GetLevel();
                text = "";
            }
            else
            {
                int level2 = theApp.mPlayerInfo.GetLevel();
                text = "";
            }
            mLevelEditWidget.SetText(text);
            base.CalcSize(110, 40);
        }

        public override void Dispose()
        {
            mLevelEditWidget.Dispose();
            base.Dispose();
        }

        public override int GetPreferredHeight(int theWidth)
        {
            return base.GetPreferredHeight(theWidth) + 40;
        }

        public override void Resize(int theX, int theY, int theWidth, int theHeight)
        {
            base.Resize(theX, theY, theWidth, theHeight);
            mLevelEditWidget.Resize(mContentInsets.mLeft + 12, mHeight - 155, mWidth - mContentInsets.mLeft - mContentInsets.mRight - 24, 28);
        }

        public override void AddedToManager(WidgetManager theWidgetManager)
        {
            base.AddedToManager(theWidgetManager);
            AddWidget(mLevelEditWidget);
            theWidgetManager.SetFocus(mLevelEditWidget);
        }

        public override void RemovedFromManager(WidgetManager theWidgetManager)
        {
            base.RemovedFromManager(theWidgetManager);
            RemoveWidget(mLevelEditWidget);
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            LawnCommon.DrawEditBox(g, mLevelEditWidget);
        }

        public virtual void EditWidgetText(int theId, string theString)
        {
            mApp.ButtonDepress(2000 + mId);
        }

        public virtual bool AllowChar(int theId, char theChar)
        {
            return true;
        }

        public bool ApplyCheat()
        {
            string text = mLevelEditWidget.mString;
			
			switch (text)
			{
				case "SDC":
					mApp.mBoard.AddZombie(ZombieType.DoorCone, GameConstants.ZOMBIE_WAVE_DEBUG);
					break;
				case "SDP":
					mApp.mBoard.AddZombie(ZombieType.DoorPail, GameConstants.ZOMBIE_WAVE_DEBUG);
					break;
				case "SDB":
					mApp.mBoard.AddZombie(ZombieType.DoorPail, GameConstants.ZOMBIE_WAVE_DEBUG);
					break;
				case "R":
					mApp.mBoard.AddZombie(ZombieType.RepeaterHead, GameConstants.ZOMBIE_WAVE_DEBUG);
					break;
				case "M":
					mApp.mBoard.AddZombie(ZombieType.Mustache, GameConstants.ZOMBIE_WAVE_DEBUG);
					break;
				default:
					mApp.mBoard.AddZombie(ZombieType.Mustache, GameConstants.ZOMBIE_WAVE_DEBUG);
					break;
			}
			
            return true;
        }

        public bool ShouldClear()
        {
            return false;
        }

        public bool AllowText(int theId, ref string theText)
        {
            return true;//return false;
        }

        public EditWidget mLevelEditWidget;
    }
}
