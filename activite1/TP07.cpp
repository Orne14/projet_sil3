#include <iostream>
using namespace std;

int main() {
    int N, T[15], i, niveau;

    cout << "Donner N (entre 4 et 15) : ";
    cin >> N;
    if (N <= 3 || N > 15) {
        cout << "N incorrect.\n";
        return 1;
    }

    for (i = 0; i < N; i++) {
        cout << "T[" << i << "] (entre 0 et 9) : ";
        cin >> T[i];
        if (T[i] < 0 || T[i] > 9) {
            cout << "Valeur incorrecte.\n";
            return 1;
        }
    }

    // Affichage de l'histogramme
    for (niveau = 9; niveau >= 1; niveau--) {
        for (i = 0; i < N; i++) {
            if (T[i] >= niveau) {
                cout << " * ";
            }
            else {
                cout << "   ";
            }
        }
        cout << "\n";
    }

    for (i = 0; i < N; i++) {
        cout << " " << i << " ";
    }
    cout << "\n";

    return 0;
}
