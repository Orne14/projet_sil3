#include <iostream>
using namespace std;

int main() {
    char prenom1[31], prenom2[31];
    int L, H;

    cout << "Saisir les deux prenoms : ";
    cin >> prenom1 >> prenom2;
    cout << "Saisir L (10 a 30) et H (15 a 25) : ";
    cin >> L >> H;

    if (L < 10 || L > 30 || H < 15 || H > 25) {
        cout << "Dimensions incorrectes.\n";
        return 1;
    }

    int longueurPrenom = 0;
    while (prenom1[longueurPrenom] != '\0') {
        longueurPrenom++;
    }

    // Affichage des prenoms sur le Z
    for (int i = 0; i < H; i++) {
        if (i == 0) {
            cout << prenom1;
        }
        else if (i == H - 1) {
            cout << prenom2;
        }
        else {
            int espace = (H - 1 - i) * (L - 1) / (H - 1);
            for (int j = 0; j < espace; j++) {
                cout << " ";
            }

            if (i < longueurPrenom) {
                cout << prenom1[i];
            }
            else {
                cout << "*";
            }
        }
        cout << "\n";
    }

    return 0;
}
