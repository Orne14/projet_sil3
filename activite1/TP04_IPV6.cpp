#include <iostream>
using namespace std;

int main() {
    int adresse[8];
    int masque[8];
    int reseau[8];
    int derniereAdresse[8];
    int prefixe;
    int tailleBloc;
    char deuxPoints;

    cout << "Saisir une IPv6 complete (ex. 2001:db8:0:0:0:0:0:1) :\n";
    cin >> hex;
    for (int i = 0; i < 8; i++) {
        cin >> adresse[i];
        if (i < 7) {
            cin >> deuxPoints;
            if (deuxPoints != ':') {
                cout << "Format IPv6 incorrect.\n";
                return 1;
            }
        }
    }

    if (cin.fail()) {
        cout << "Format IPv6 incorrect.\n";
        return 1;
    }

    cin >> dec;
    cout << "Saisir le prefixe (0 a 128) : ";
    cin >> prefixe;
    if (cin.fail() || prefixe < 0 || prefixe > 128) {
        cout << "Prefixe incorrect.\n";
        return 1;
    }

    // Verification des groupes
    for (int i = 0; i < 8; i++) {
        if (adresse[i] < 0 || adresse[i] > 65535) {
            cout << "Groupe IPv6 incorrect.\n";
            return 1;
        }
    }

    // Calcul du masque et des limites du prefixe
    for (int i = 0; i < 8; i++) {
        int bits = prefixe - i * 16;
        tailleBloc = 1;

        if (bits >= 16) {
            masque[i] = 65535;
        }
        else if (bits <= 0) {
            for (int j = 0; j < 16; j++) {
                tailleBloc = tailleBloc * 2;
            }
            masque[i] = 0;
        }
        else {
            for (int j = bits; j < 16; j++) {
                tailleBloc = tailleBloc * 2;
            }
            masque[i] = 65536 - tailleBloc;
        }

        reseau[i] = (adresse[i] / tailleBloc) * tailleBloc;
        derniereAdresse[i] = reseau[i] + tailleBloc - 1;
    }

    cout << "Masque : ";
    for (int i = 0; i < 8; i++) {
        cout << hex << masque[i];
        if (i < 7) {
            cout << ":";
        }
    }

    cout << "\nAdresse reseau : ";
    for (int i = 0; i < 8; i++) {
        cout << hex << reseau[i];
        if (i < 7) {
            cout << ":";
        }
    }

    cout << dec << "/" << prefixe << "\nFin de la plage du prefixe : ";
    for (int i = 0; i < 8; i++) {
        cout << hex << derniereAdresse[i];
        if (i < 7) {
            cout << ":";
        }
    }

    cout << dec << "\nIPv6 n'a pas de classe ni d'adresse de diffusion.\n";
    return 0;
}
