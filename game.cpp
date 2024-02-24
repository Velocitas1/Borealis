#include "card.h"
#include "game.h"
#include <iostream>
using namespace std;
Game::Game()
{
    mDeck = new Deck();
}
void Game::StartGame()
{
    cout << "StartGame()" << endl;
    mDeck->drawOneCard();
}