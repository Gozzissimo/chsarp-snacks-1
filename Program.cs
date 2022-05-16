// See https://aka.ms/new-console-template for more information

var len = "fkjbsjbesbsfkjvcs".Length; //Equivale a int len..

//Costruire una stringa lunga 1000 caratteri
string millea = new string('a', 1000);

//Per oncatenare molte stringhe uso StringBuilder

string lunga = new string('a', 1000);
string lungb = new string('a', 1000);

string lungab = lunga + lungb + millea;

foreach (char c in lungab.Distinct<char>())
{
    Console.WriteLine(c);
}

//Operatore Modulo
//Il software chiede all'utente di inserire un numero.
//Se il numero è pari stampa il numero, se è dispare, sampa il successivo

int num = -20;
Console.WriteLine(Math.Abs(num));
Console.WriteLine(Math.BitIncrement(12)); // => 12,000000000000002  MAX 15 CIFRE DECIMALI
Console.WriteLine(Math.BitDecrement(12)); // => 11,999999999999998  MAX 15 CIFRE DECIMALI

//Operatore modulo: il resto della divisione intera
Console.WriteLine(20 % 6); // 20 modulo 6 = 2 ---> (20 / 6 = 18 --> 20 - 18 = 2)

//Array in csharp

//Array di caratteri
char[] v;

//Array di interi
int[] vi;

//Array di booleani
bool[] vb;

//Array di reali
double[] vd;
    
//Array di stringhe
string[] vs;

//Array di array, ma sempre di qualcosa
int[][] vii;

//un esempio di inizializzazione di un vettore di stringhe
string[] vs1 = new string[] { "uno", "due", "tre", "quattro"};


//----------------------------------

//!!!in tutti i linguaggi abbiamo due funzioni/metodi/operatori MOLTO UTILI:

//MAP
//Map applica una funzione a tutti gli elementi di una sequenza e ottiene una sequenza simile di pari dimensioni con i risultati della funzione
//Map può essere eseguita in PARALLELO senza perdere di significatività
//non conosciamo l'ordine in cui la funzione viene applicata ai singoli elementi della sequenza
//NB: la funzione applicata si aspetta un solo parametro, l'elemento corrente 

//REDUCE
//Applica "iterativamente" (non in parallelo) una funzione a tutti gli elementi di una sequenza e torna il risultato finale della funzione
//La funzione applicata si aspetta DUE parametri: l'elemento corrente e il risultato dell'applicazione precedente

//fatto sulle liste ad esempio
/*
 * (1 2 3 4 5 6 7 8 9 10) e applica il + con la reduce =>
 * prima chiamata (+ 1 2) => 3
 * seconda chiamata (+ 3 3) => 6
 * terza chiamata (+ 4 6) => 10
 * quarta chiamata (+ 5 10) => 15
    ...
*/

//voglio contare quante stringhe ci sono nel vettore
Console.WriteLine(vs1.Aggregate(0, (old, current) => old + 1));

//voglio contare la lunghezza totale delle stringhe nel vettore
Console.WriteLine(vs1.Aggregate(0, (old, current) => old + current.Length));

/*
 * (old, current)               => old + current.length
 * PARAMETRI DI CHIAMATA       CORPO DELLA FUNZIONE, ULTIMA SITRUZIONE è IL RETURN (implicito)
 */

//voglio trovare la stringa + lunga
Console.WriteLine(vs1.Aggregate("", (old, current) => (old.Length >= current.Length) ? old : current)); //Usato il ternario
// se partendo da una stringa vuota "" andiamo avanti, ridammi la stringa old se questa è più lunga della current

//Lo utilizzo come se fosse una find
Console.WriteLine(vs1.Aggregate(false, (old, current) => old ? true : (("pippo".CompareTo(current) == 0) ? true : false)));


List<int> li = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Console.WriteLine(li.Aggregate(0, (old, current) => old + current));

//----------------------------------------------------------------------------

//Crea un array di numeri interi e fai la somma di tutti quelli in posizione dispari
int[] arr = new int[] { 3, 5, 7, 8, 9, 6, 8, 1, 2, 3, 4, 5, 6, 7 };

//esempio1
int totale = 0;
for (int i = 0; i < arr.Length; i++)
{
    if ((i % 2) != 0)
    {
        totale = totale + arr[i];
    }
}
//esempio2
int totale1 = 0;
for (int i = 1; i < arr.Length; i+=2)
{
    totale1 = totale1 + arr[i];
}


arr.Aggregate(0, (int prec, int current) =>
{
    if ((current % 2) != 0)
        return prec + current;
    else
        return prec;
});

//Scopriamo in che ordine opera la aggregate
string[] vs3 = new string[] { "uno", "due", "tre" };
vs3.Aggregate("", (string old, string current) =>
{
    Console.WriteLine(current);
    return "";
});
//Stampa "uno" "due" "tre". L'ordine della aggregate è dal primo all'ultimo.
