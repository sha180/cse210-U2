using System;
using System.Collections.Generic;
using cse210_U2.game.player;

namespace cse210_U2.game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        bool isPlaying = true;

        Card tmpCard;
        int cardIndex;
        List<Card> deck = new List<Card>();
        
        List<Player> players = new List<Player>();

        int playerCount = 1;
        int curentplayer;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            Console.Write("how many are playing?: ");
            playerCount = getIntFromCMD();
            Console.WriteLine();

            for (int k = 0; k < playerCount; k++){
                Player player = new Player(k);
                players.Add(player);
            }

            for (int j = 0; j < 5; j ++){
                for (int i = 0; i < 13; i++){
                    Card card = new Card();
                    card.setValue(i + 1);
                    deck.Add(card);
                }
            }
        }

        /// <summary>
        /// Starts the game by delling out a first round of cards
        /// than enters the main loop and goes until there are no cards
        /// or til all the player have 0 points
        /// </summary>
        public void StartGame()
        {
            firstRount();

            while (isPlaying)
            {
                NextRound();
            }
        }

        /// <summary>
        /// Starts the game by geting all players a card.
        /// </summary>
        void firstRount(){
            for(curentplayer = 0; curentplayer < playerCount; curentplayer++){

                    Console.WriteLine($"player {curentplayer + 1}'s turn");
                    
                    DrawCard();

                    Console.WriteLine("The card is: " + tmpCard.getValue());

                    players[curentplayer].setPrevCard(tmpCard);
                    
                    GetInputs();
                    

            }
        }

        
        /// <summary>
        /// Starts the game by geting all players a card.
        /// </summary>
        void NextRound(){
            
                for(curentplayer = 0; curentplayer < playerCount; curentplayer++){
                    Console.WriteLine($"player {curentplayer + 1}'s turn");
                    
                    tmpCard = players[curentplayer].getPrevCard();
                    
                    Console.WriteLine("The card is: " + tmpCard.getValue());
                    
                    GetInputs();

                    CheckDeck();
                }
        }

        /// <summary>
        /// Asks the user if the next card will be higher or lower.
        /// </summary>
        public void GetInputs()
        {
            Console.Write("Higher or Lower? [h/l/#] ");
            string playerInput = Console.ReadLine().ToLower();
            

                
                isPlaying = prosessInput(playerInput);
            
                players[curentplayer].setPrevCard(tmpCard);
                Console.WriteLine();
        }

        /// <summary>
        /// Updates the player's score. 
        /// and prints it to the Console
        /// </summary>
        public void DoUpdates()
        {
            if (!isPlaying)
            {
                return; 
            }

            bool CardCheck = true;
            
            while (CardCheck)
            {
                DrawCard();
                // Console.WriteLine($"tmpCard == {tmpCard.getValue()}");
                // Console.WriteLine($"players card == {players[curentplayer].getPrevCard().getValue()}");
                if(players[curentplayer].getPrevCard().getValue() != tmpCard.getValue()){
                // Console.WriteLine($"tmpCard == {tmpCard.getValue()}");
                    deck.RemoveAt(cardIndex);
                    CardCheck = false;
                }
            }
                
            Console.WriteLine("Next card was: " + tmpCard.getValue());

            // if(guess){
            //     players[curentplayer].AddPoints(100);
            // }else {
            //     players[curentplayer].SubPoints(75);
            // }

            // Console.WriteLine( $"Player: {curentplayer + 1}'s score is: {players[curentplayer].getPoints()}");

        }

        /// <summary>
        /// picks a card instance from the deck list
        /// and saves it to a timperary card;
        /// </summary>
        public void DrawCard(){
            Random random = new Random();
            cardIndex = random.Next(deck.Count);
            tmpCard = deck[cardIndex];
        }

        /// <summary>
        /// Checks if there are any items in the Deck list.
        /// and ends the game if it is empty
        /// </summary>
        bool prosessInput(string input){

            switch (input)
            {
                case "l":
                    
                    DoUpdates();
                    
            if(players[curentplayer].getPrevCard().getValue() > tmpCard.getValue()){
                players[curentplayer].AddPoints(100);
            }else {
                players[curentplayer].SubPoints(75);
            }

            Console.WriteLine( $"Player: {curentplayer + 1}'s score is: {players[curentplayer].getPoints()}");
                    break;

                case "h":
            

                    DoUpdates();

            if(players[curentplayer].getPrevCard().getValue() < tmpCard.getValue()){
                players[curentplayer].AddPoints(100);
            }else {
                players[curentplayer].SubPoints(75);
            }

            Console.WriteLine( $"Player: {curentplayer + 1}'s score is: {players[curentplayer].getPoints()}");
                    break;

                case "#":
                    // settings.changeSetting();
                    GetInputs();
                    return false;
                default:
                    Console.WriteLine("enter a valid option");
                    GetInputs();
                    break;
            }


            return true;

        }

        void CheckCard(){

            bool CardCheck = true;
            while (CardCheck)
            {
                DrawCard();
                Console.WriteLine($"tmpCard == {tmpCard.getValue()}");
                Console.WriteLine($"players card == {players[curentplayer].getPrevCard().getValue()}");
                if(players[curentplayer].getPrevCard().getValue() != tmpCard.getValue()){
                Console.WriteLine($"tmpCard == {tmpCard.getValue()}");
                    deck.RemoveAt(cardIndex);
                    CardCheck = false;
                }
            }
                
            Console.WriteLine("Next card was: " + tmpCard.getValue());
        }
        /// <summary>
        /// Checks if there are any items in the Deck list.
        /// and ends the game if it is empty
        /// </summary>
        void CheckDeck(){
            if (!(deck.Count > 0)){

                Console.WriteLine("deck is out of cards. game over.");
                isPlaying = false;
                gameOver();
            }


            
        }

        void gameOver(){
            if(isPlaying){
                Console.WriteLine("you won! want to play again?");
                // totalScore = 0;
            } else{
                
                Console.WriteLine("better luck next time");
            }
        }

        // retreves an intiger from user input
        public static int getIntFromCMD(){

            string input = Console.ReadLine();
 
            if (!int.TryParse(input, out int num)){
                if (input != null)
                input = input.ToLower();


                Console.WriteLine( input + " is not a number!");
                return -1;
            }else{
                return num;
            }
        }

    }
}


