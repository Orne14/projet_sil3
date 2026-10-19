#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

int main() {
    int combinaison[5];
    int proposition[5];
    int bienPlaces = 0;
    int essai = 0;
    int maximum;

    cout << "Nombre maximum d'essais : ";
    cin >> maximum;
    while (maximum <= 0) {
        cout << "Donner un nombre positif : ";
        cin >> maximum;
    }

    srand(time(0));

    // Tirage de la combinaison cachee
    for (int i = 0; i < 5; i++) {
        combinaison[i] = rand() % 9 + 1;
    }

    // Saisie des propositions
    do {
        essai++;
        bienPlaces = 0;

        cout << "Essai " << essai << " : saisir cinq chiffres de 1 a 9 : ";
        for (int i = 0; i < 5; i++) {
            cin >> proposition[i];
            while (proposition[i] < 1 || proposition[i] > 9) {
                cout << "Saisir un chiffre entre 1 et 9 : ";
                cin >> proposition[i];
            }
        }

        // Comptage des numeros bien places
        for (int i = 0; i < 5; i++) {
            if (proposition[i] == combinaison[i]) {
                bienPlaces++;
            }
        }
        cout << bienPlaces << " numero(s) bien place(s)\n";
    } while (bienPlaces != 5 && essai < maximum);

    // Affichage du resultat
    if (bienPlaces == 5) {
        cout << "Bravo, vous avez gagne en " << essai << " essais !\n";
    }
    else {
        cout << "Vous avez perdu ! La combinaison etait : ";
        for (int i = 0; i < 5; i++) {
            cout << combinaison[i] << " ";
        }
        cout << "\n";
    }

    return 0;
}
