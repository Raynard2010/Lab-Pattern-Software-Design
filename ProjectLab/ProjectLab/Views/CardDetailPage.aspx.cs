using System;
using ProjectLab.Models;

using ProjectLab.Handlers;

namespace ProjectLab.Views
{
    public partial class CardDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CardId"] == null)
                {
                    ShowError("No card ID provided.");
                    return;
                }

                int cardId;
                bool isValidId = int.TryParse(Request.QueryString["CardId"], out cardId);
                if (!isValidId)
                {
                    ShowError("Invalid card ID.");
                    return;
                }

                Card card = CardHandler.GetCardById(cardId);
                if (card == null)
                {
                    ShowError("Card not found.");
                    return;
                }

                DisplayCard(card);
            }
        }

        private void ShowError(string message)
        {
            LblError.Text = message;
            LblError.Visible = true;
            PanelCardDetail.Visible = false;
        }

        private void DisplayCard(Card card)
        {
            LblName.Text = card.CardName;
            LblPrice.Text = card.CardPrice.ToString(); 
            LblType.Text = card.CardType;
            LblDescription.Text = card.CardDesc;

            PanelCardDetail.Visible = true;
            LblError.Visible = false;
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderCard.aspx");
        }
    }
}
