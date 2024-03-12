#ifndef __CARD_H__
#define __CARD_H__
#include <vector>
typedef enum
{
    Hearts = 0,
    Clubs = 1,
    Diamonds = 2,
    Spades = 3,
    MaxSuit =4,
} Suit;
class Card
{
public:
    Card(Suit aSuit, short aValue):
    mSuit(aSuit),mValue(aValue) {};
    ~Card() {};
    void ShowCard();
private:
    Suit mSuit;
    short mValue;
};
class Deck
{
public:
    Deck()
    {
        for(int loopSuit=Hearts; loopSuit<MaxSuit; ++loopSuit)
        {
            for(int i=1; i<14; ++i)
            {
                Card theCard(loopSuit, i);
                mCards.push_back(theCard);
            }
        }        
    };
    ~Deck();
    Card drawOneCard();
private:
    vector<Card> mCards;
};
#endif