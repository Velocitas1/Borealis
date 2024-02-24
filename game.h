#include "card.h"
#ifndef __GAME_H__
#define __GAME_H__
class Game
{
public:
    Game();
    ~Game(){};
    void StartGame();
private:
    Deck* mDeck;
};
#endif