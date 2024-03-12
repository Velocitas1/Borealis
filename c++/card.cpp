#include <iostream>
#include "card.h"
using namespace std;
void Card::ShowCard(){
    cout << "You got a " << mValue << endl;
}
Card Deck::drawOneCard(){
    // Get a random number from the vector
    Card randomCard = mCards[rand() % mCards.size()];
    randomCard.ShowCard();
    return randomCard;
}