#include <iostream>
using namespace std;

int main() {
    int dosse, dossmt, dossmt2;
    double tc, mt, mt2;

    // Saisie du premier concurrent
    cout << "Dossard (0 pour terminer) : ";
    cin >> dosse;
    while (cin.fail() || dosse < 0) {
        cin.clear();
        cin.ignore(1000, '\n');
        cout << "Dossard positif ou nul : ";
        cin >> dosse;
    }

    if (dosse == 0) {
        cout << "Aucun concurrent saisi.\n";
        return 0;
    }

    cout << "Temps : ";
    cin >> tc;
    dossmt = dosse;
    mt = tc;
    dossmt2 = 0;
    mt2 = 0;

    // Recherche des deux meilleurs temps
    cout << "Dossard (0 pour terminer) : ";
    cin >> dosse;

    while (dosse != 0) {
        while (cin.fail() || dosse < 0) {
            cin.clear();
            cin.ignore(1000, '\n');
            cout << "Dossard positif ou nul : ";
            cin >> dosse;
        }

        if (dosse != 0) {
            cout << "Temps : ";
            cin >> tc;

            if (tc < mt) {
                mt2 = mt;
                dossmt2 = dossmt;
                mt = tc;
                dossmt = dosse;
            }
            else if (dossmt2 == 0 || tc < mt2) {
                mt2 = tc;
                dossmt2 = dosse;
            }

            cout << "Dossard (0 pour terminer) : ";
            cin >> dosse;
        }
    }

    cout << "Le vainqueur est : " << dossmt << ", son temps est : " << mt << "\n";
    if (dossmt2 != 0) {
        cout << "Deuxieme : " << dossmt2 << ", son temps est : " << mt2 << "\n";
    }

    return 0;
}
