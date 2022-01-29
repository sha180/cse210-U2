

namespace cse210_U2.game
{
    class Card
    {
        int cardValue;

        public Card()
        {

        }

        public int getValue(){
            return cardValue;
        }
        public void setValue(int value){
            cardValue = value;
        }

        public bool isHigher(Card cardInst){
            if (cardInst.cardValue > cardValue){
            return true;
            } 
            return false;
        }
        public bool isLower(Card cardInst){
            if (cardInst.getValue() < cardValue){
            return true;
            } 
            return false;
        }
    }
}
