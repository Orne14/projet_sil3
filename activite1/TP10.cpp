#include <iostream>
using namespace std;

class Compteur {
private:
    int valeur;

public:
    Compteur() {
        valeur = 0;
    }

    void incrementer() {
        valeur = valeur + 1;
    }

    void decrementer() {
        if (valeur > 0) {
            valeur = valeur - 1;
        }
    }

    int lireValeur() {
        return valeur;
    }
};

int main() {
    Compteur c;

    cout << c.lireValeur() << " ";
    for (int i = 0; i < 10; i++) {
        c.incrementer();
    }
    cout << c.lireValeur() << " ";

    for (int i = 0; i < 20; i++) {
        c.decrementer();
    }
    cout << c.lireValeur() << "\n";

    return 0;
}
