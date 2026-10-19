#include <iostream>
using namespace std;

int main() {
    int X, Y, Z, T, N;
    int adresse[4], masque[4];
    int premierReseau[4], dernierReseau[4];
    int diffusionPremier[4], diffusionDernier[4];
    int prefixeClasse;
    int nombreSousReseaux = 1;
    int nombreHotes = 1;
    char point1, point2, point3, barre;
    char classe;

    cout << "Saisir l'adresse X.Y.Z.T/N : ";
    cin >> X >> point1 >> Y >> point2 >> Z >> point3 >> T >> barre >> N;

    if (cin.fail() || point1 != '.' || point2 != '.' || point3 != '.' || barre != '/') {
        cout << "Format incorrect.\n";
        return 1;
    }

    adresse[0] = X;
    adresse[1] = Y;
    adresse[2] = Z;
    adresse[3] = T;

    // Verification de l'adresse
    for (int i = 0; i < 4; i++) {
        if (adresse[i] < 0 || adresse[i] > 255) {
            cout << "Adresse IP incorrecte.\n";
            return 1;
        }
    }

    // Recherche de la classe
    if (X >= 1 && X <= 126) {
        classe = 'A';
        prefixeClasse = 8;
    }
    else if (X >= 128 && X <= 191) {
        classe = 'B';
        prefixeClasse = 16;
    }
    else if (X >= 192 && X <= 223) {
        classe = 'C';
        prefixeClasse = 24;
    }
    else {
        cout << "Adresse speciale ou inexploitable.\n";
        return 1;
    }

    if (N < prefixeClasse || N > 30) {
        cout << "N incorrect pour cette classe.\n";
        return 1;
    }

    // Calcul du masque
    for (int i = 0; i < 4; i++) {
        int bitsOctet = N - i * 8;
        if (bitsOctet >= 8) {
            masque[i] = 255;
        }
        else if (bitsOctet <= 0) {
            masque[i] = 0;
        }
        else {
            masque[i] = 0;
            int poids = 128;
            for (int j = 0; j < bitsOctet; j++) {
                masque[i] = masque[i] + poids;
                poids = poids / 2;
            }
        }
    }

    // Calcul du nombre de sous-reseaux et d'hotes
    for (int i = 0; i < N - prefixeClasse; i++) {
        nombreSousReseaux = nombreSousReseaux * 2;
    }
    for (int i = 0; i < 32 - N; i++) {
        nombreHotes = nombreHotes * 2;
    }
    nombreHotes = nombreHotes - 2;

    // Calcul des adresses des sous-reseaux
    for (int i = 0; i < 4; i++) {
        premierReseau[i] = adresse[i];
        if (i >= prefixeClasse / 8) {
            premierReseau[i] = 0;
        }
        dernierReseau[i] = premierReseau[i];
    }

    for (int bit = prefixeClasse; bit < N; bit++) {
        int octet = bit / 8;
        int poids = 128;
        for (int j = 0; j < bit % 8; j++) {
            poids = poids / 2;
        }
        dernierReseau[octet] = dernierReseau[octet] + poids;
    }

    // Calcul des adresses de diffusion
    for (int i = 0; i < 4; i++) {
        diffusionPremier[i] = premierReseau[i] + (255 - masque[i]);
        diffusionDernier[i] = dernierReseau[i] + (255 - masque[i]);
    }

    cout << "Classe : " << classe << "\nMasque : ";
    for (int i = 0; i < 4; i++) {
        cout << masque[i];
        if (i < 3) {
            cout << ".";
        }
    }
    cout << "\nNombre de sous-reseaux : " << nombreSousReseaux;
    cout << "\nNombre d'hotes par sous-reseau : " << nombreHotes << "\n";

    cout << "Premier sous-reseau : ";
    for (int i = 0; i < 4; i++) {
        cout << premierReseau[i];
        if (i < 3) {
            cout << ".";
        }
    }
    cout << "/" << N << "\nDiffusion : ";
    for (int i = 0; i < 4; i++) {
        cout << diffusionPremier[i];
        if (i < 3) {
            cout << ".";
        }
    }

    cout << "\nHotes : ";
    for (int i = 0; i < 4; i++) {
        int hote = premierReseau[i];
        if (i == 3) {
            hote++;
        }
        cout << hote;
        if (i < 3) {
            cout << ".";
        }
    }
    cout << " - ";
    for (int i = 0; i < 4; i++) {
        int hote = diffusionPremier[i];
        if (i == 3) {
            hote--;
        }
        cout << hote;
        if (i < 3) {
            cout << ".";
        }
    }

    cout << "\nDernier sous-reseau : ";
    for (int i = 0; i < 4; i++) {
        cout << dernierReseau[i];
        if (i < 3) {
            cout << ".";
        }
    }
    cout << "/" << N << "\nDiffusion : ";
    for (int i = 0; i < 4; i++) {
        cout << diffusionDernier[i];
        if (i < 3) {
            cout << ".";
        }
    }

    cout << "\nHotes : ";
    for (int i = 0; i < 4; i++) {
        int hote = dernierReseau[i];
        if (i == 3) {
            hote++;
        }
        cout << hote;
        if (i < 3) {
            cout << ".";
        }
    }
    cout << " - ";
    for (int i = 0; i < 4; i++) {
        int hote = diffusionDernier[i];
        if (i == 3) {
            hote--;
        }
        cout << hote;
        if (i < 3) {
            cout << ".";
        }
    }
    cout << "\n";

    return 0;
}
