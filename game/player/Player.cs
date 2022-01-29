

namespace cse210_U2.game.player
{
    class Player
    {
        Card PrevCard;
        int points;
        
        int playerID;
        public Player(int ID)
        {
            points = 300;
            playerID = ID;
        }

        public void SubPoints(int amount){
            points -= amount;
        }
        public void AddPoints(int amount){
            points += amount;
        }
        public int getPoints(){
            return points;
        }

        public void setPrevCard(Card card){
            PrevCard = card;
        }
        public Card getPrevCard(){
            return PrevCard;
        }
    }
}
