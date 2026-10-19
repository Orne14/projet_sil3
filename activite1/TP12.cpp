#include <iostream>
using namespace std;

int main() {
    int X, Y, Z, T;
    int masque[4], reseau[4], diffusion[4];
    int adresse[4];
    char classe;

    cout << "Saisir X, Y, Z et T : ";
    cin >> X >> Y >> Z >> T;
    if (cin.fail()) {
        cout << "Adresse IPv4 incorrecte.\n";
        return 1;
    }
    adresse[0] = X;
    adresse[1] = Y;
    adresse[2] = Z;
    adresse[3] = T;

    // Verification de l'adresse
    for (int i = 0; i < 4; i++) {
        if (adresse[i] < 0 || adresse[i] > 255) {
            cout << "Adresse IPv4 incorrecte.\n";
            return 1;
        }
    }

    // Recherche de la classe et du masque
    if (X >= 1 && X <= 126) {
        classe = 'A';
        masque[0] = 255;
        masque[1] = 0;
        masque[2] = 0;
        masque[3] = 0;
    }
    else if (X >= 128 && X <= 191) {
        classe = 'B';
        masque[0] = 255;
        masque[1] = 255;
        masque[2] = 0;
        masque[3] = 0;
    }
    else if (X >= 192 && X <= 223) {
        classe = 'C';
        masque[0] = 255;
        masque[1] = 255;
        masque[2] = 255;
        masque[3] = 0;
    }
    else {
        cout << "Adresse speciale ou inexploitable.\n";
        return 1;
    }

    // Calcul du reseau et de la diffusion
    for (int i = 0; i < 4; i++) {
        if (masque[i] == 255) {
            reseau[i] = adresse[i];
            diffusion[i] = adresse[i];
        }
        else {
            reseau[i] = 0;
            diffusion[i] = 255;
        }
    }

    // Verification d'une adresse reseau ou diffusion
    bool adresseReseau = true;
    bool adresseDiffusion = true;
    for (int i = 0; i < 4; i++) {
        if (adresse[i] != reseau[i]) {
            adresseReseau = false;
        }
        if (adresse[i] != diffusion[i]) {
            adresseDiffusion = false;
        }
    }

    if (adresseReseau || adresseDiffusion) {
        cout << "Adresse reseau ou diffusion, donc inexploitable comme adresse d'hote.\n";
        return 1;
    }

    cout << "Classe : " << classe << "\nMasque : ";
    for (int i = 0; i < 4; i++) {
        cout << masque[i];
        if (i < 3) {
            cout << ".";
        }
    }

    cout << "\nAdresse reseau : ";
    for (int i = 0; i < 4; i++) {
        cout << reseau[i];
        if (i < 3) {
            cout << ".";
        }
    }

    cout << "\nAdresse de diffusion : ";
    for (int i = 0; i < 4; i++) {
        cout << diffusion[i];
        if (i < 3) {
            cout << ".";
        }
    }

    reseau[3]++;
    diffusion[3]--;

    cout << "\nPlage des hotes : ";
    for (int i = 0; i < 4; i++) {
        cout << reseau[i];
        if (i < 3) {
            cout << ".";
        }
    }
    cout << " - ";

    for (int i = 0; i < 4; i++) {
        cout << diffusion[i];
        if (i < 3) {
            cout << ".";
        }
    }
    cout << "\n";

    return 0;
}
