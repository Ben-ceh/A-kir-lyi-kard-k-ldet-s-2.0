using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Fő menü
            Random vszam = new Random();
            //
            double[] jatekosStatja = { 350, 65 };
            double[] jatekosKardSebzes = { 0, 0 };
            double[] jatekosPancelEletero = { 0 };
            string[] jatekosHatitaska = { "Királyi Kard", "Királyi Páncél", " " };
            int jatekosExpLVL = 1;
            int jatekosExp = 0;
            int jatekosPenztarca = 10;

            string[] kiralynoNev = { "Isabella Királynő", "Viktória királynő", "Erzsébet Királynő", "Mahiana Roszallo" };
            int db00 = 0;

            string[] boltKardAsvany = { "Tűzfény Kristály", "Kék Árnyék Kő", "Mosszöld Obszidián", "Ezüst Holdkő", "Lángoló Zafír", "Pókfonál Kő", "Éjfél Tűz Kő", "Fagyott Lúdtoll Kristály", "Vihar Lángja", "Ősi Csillagfény" };
            string[] boltKardAsvanyMagyarazat = {
                    "Ez a vöröses színű ásvány a barlang falain elterjedt. Megjelenése ragyogó, szinte izzik a fénytől, és gyakran használják varázslatokhoz.",
                    "Egy mélykék színű ásvány, amely tompított fényt bocsát ki. A goblinok számára szinte a sötétségben való tájékozódást segítő eszközként szolgál.",
                 "Zöldes árnyalatú obszidián, amely az erdei területekről származik. Az ásványt gyakran használják gyógyító varázslatokhoz és védelmi varázslatokhoz.",
                        "Ez a fénylő, szürke ásvány különleges tükröződést ad, amely a holdfény hatására ragyog. Az elrejtett járatok navigálásához ideális.",
                    "Ritka, égett narancssárga zafír, amely erős mágikus energiát bocsát ki. A goblinok gyakran elrejtik az értékes darabokat, hogy védjék őket a kíváncsiskodóktól.",
                 "Szürke, szálas szerkezetű ásvány, amely a barlang mélyebb, sötétebb zugaiban található. Állítólag képes megállítani a mérgeket és elnyelni a sötét varázslatokat.",
                     "Sötét, fekete színű ásvány, amit egy titokzatos fénypont villanása jellemez. A legritkább helyeken található, és mágikus védelmet biztosít a sötétség ellen.",
                         "Egy átlátszó, szinte teljesen fehér ásvány, amely a jég birodalmait idézi. Hideg, jéghideg energia sugárzik belőle, és rendkívül nehezen hozzáférhető.",
                     "Hatalmas erejű, kék és zöld színben játszó ásvány, amely a villámlás hatására aktiválódik. Rendkívül ritka, és a legveszélyesebb goblinok is félnek tőle.",
                         "A legritkább és leghatalmasabb kristály, amely egykor a világ kezdeti fényét hordozta. A csillagok szikrázó fénye ragyog belőle, és csupán néhány darab létezik. A varázslók titkos elixíreket készítenek belőle."
                    };

            string[] boltPancelAsvany = { "Fénytörő Obszidián", "Vérvörös Jaspis", "Holdfény Amatészter", "Ékkő Tükrözült", "Fekete Szivárvány", "Tűzvirág Kristály ", "Víz Tükörkő", "Csontfehér Kő", "Zöld Fény Kristály", "Fekete Holdkő" };
            string[] boltPancelAsvanyMagyarazat = {
                            "Egy különleges fekete üveg, amely hajlítja és szórja a fényt, rendkívül ritka és nagy erejű védelmi eszközként használják.",
                     "Mély vörös színű kő, amelyet egyesek vérrel festettnek tartanak. A harcosok a vérvörös jaspist a csatatéren használják, hogy megőrizzék erejüket.",
                      "Egy szikrázó lila kristály, amely a holdfényben ragyog, és az álomvilágokba vezető varázslatok egyik kulcseleme.",
                       "Egy ritka, tükröződő kő, amely képes felnagyítani és visszaverni a környezetében lévő fényeket. A varázslók gyakran használják illúziók létrehozására.",
                      "A fekete üveges kő különböző színekben játszik a fény hatására, így varázslatos hatásokra képes. A varázslók számára különleges erővel bír.",
                      "Egy ragyogó narancssárga kristály, amely lángra lobbantja a közelében lévő anyagokat. A tűzvarázslók számára elengedhetetlen.",
                 "Egy áttetsző, vízszínű ásvány, amely tükrözi a körülötte lévő vízfelületeket. A tengerész varázslók gyakran használják a navigációs varázslataikhoz.",
                     "Egy sápadt, fehér ásvány, amely képes előhívni az ősök szellemeit, így spirituális és kommunikációs célokra is hasznos.",
                     "Egy smaragdzöld kristály, amely az életenergia növelésére használható. A gyógyítók és druida rendek legfontosabb eszköze.",
                     "Sötét színű, fénylő ásvány, amely a mágikus holdfény hatására aktiválódik. Titkos erővel bír, amely képes elnyelni a negatív energiákat."
                    };
            string[] idezetek = {
    "Ahol nincs kockázat a feladatban, ott nem lehet dicsőség a megvalósításában.",
    "Édesapám azt mondta a lovagkiképzésem alatt hogy: Az igazi lovagot nem a kard teszi, hanem az önzetlenség.\n"+
    "Becsület nélkül a lovag nem több egyszerű gyilkosnál.\n"+
    "Jobb becsülettel meghalni, mint anélkül élni.",
    "Még a legigazabb lovag sem védelmezhet meg egy királyt saját maga ellen.",
    "Minden férfi bolond, és minden férfi lovag is, ha nőkről van szó.",
    "Egy bátor besúgó ugyanolyan haszontalan volna, mint egy gyáva lovag.",
    "Az, hogy valaki férfi, még nem jelenti azt, hogy ne viselkedhetne lovag módjára.",
   // "Egy lovag három okból ránt kardot:\n hogy megvédje magát, hogy megvédje a gyengéket,\n és hogy megvédje az urát.\n De (...) sohase védd magad az igazsággal szemben,\n sohase védelmezd a gyengeséget másokban,\n és sohase védelmezz egy becstelen urat!",
    "Nagyon érdekes hogy mennyi ember szégyelli a testét, és milyen kevesen az agyát...",
    "A bátorság a szívben kezdődik, nem a fegyverekben.",
    "A lovagok hűsége a legnagyobb erény.",
    "A lovagok mindig a gyengék védelmezői.",
    "A lovag nem harcol önmagáért, hanem másokért.",
    "A becsület a lovag legfőbb fegyvere.",
    "A tisztesség és a tisztességesség a lovag igazi erőforrásai.",
    "A valódi lovag a szívében harcol. – Ismeretlen",
    "A lovagi erények örök érvényűek, mint a csillagok az égen.",
    "A lovag nem a félelmet követi, hanem a becsületet.",
    "A lovagi erő nem a kardban rejlik, hanem a lélekben.",
    "A szív ereje határozza meg a lovag valós bátorságát.",
    "A lovagok nem a háborúkat, hanem a békét szolgálják.",
    "A lovagi erények örökösek, soha nem feledkezhetünk meg róluk.",
    "A lovagok nem hajolnak meg a világ előtt, csak a tisztesség előtt.",
    "A lovagok tisztelik a nőket, mert ők az élet védelmezői.",
    "A lovagi szellem az önfeláldozásról és az igazságról szól.",
    "A kard akkor is hasznos, ha a becsület vezeti a kezünket.",
    "A lovag igazi ereje abban rejlik, hogy képes megvédeni azt, ami fontos.",
    "A hűség a lovag legértékesebb kincse.",
    "A lovagi élet nem a dicsőség kereséséről szól, hanem az igazság szolgálatáról."
};


            double[] mobokStatja = { 100, 25 };  // Wave-enként novekszik
            double[] mobMiniBoss = { 500, 100 };  // MiniBoss legyozese utan novekszik
            double[] mobFinalBoss = { 750, 150 }; // FinalBoss legyozese utan novekszik
            int waveCounter = 1;
            //
            string[] szovegek = { "Üdvözzöllek A királyi kard Küldetés játékban", "Kaland játék,", "Készítette: Nagy Sándor & Komóczi Bence" };
            int y = Console.WindowHeight / 2 - szovegek.Length / 2;

            foreach (string szoveg in szovegek)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - szoveg.Length / 2, y++);
                Console.WriteLine(szoveg);
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }

            string startFelirat = "|START|";
            int konzolSzelesseg = Console.WindowWidth;
            string kozepre = startFelirat.PadLeft((konzolSzelesseg + startFelirat.Length) / 2);

            Console.WriteLine(kozepre);

            Console.ReadLine();
            Console.Clear();
            goto fomenu1;
        //
        fomenu1:
            // uj jatek.
            Console.WriteLine(@"                                                                                                |
                                                                                            .   |
                                                                                                |
                                                                                  \    *        |     *    .  /
                                                                                    \        *  |  .        /
                                                                                 .    \     ___---___     /    .  
                                                                                        \.--         --./     
                                                                             ~-_    *  ./               \.   *   _-~
                                                                                ~-_   /                   \   _-~     *
                                                                           *       ~-/                     \-~        
                                                                             .      |                       |      .
                                                                                 * |                         | *     
                                                                        -----------|                         |-----------
                                                                          .        |                         |        .    
                                                                                *   |                       | *
                                                                                   _-\                     /-_    *
                                                                             .  _-~ . \                   /   ~-_     
                                                                             _-~       `\               /'*      ~-_  
                                                                            ~           /`--___   ___--'\           ~
                                                                                   *  /        ---     .  \   
                                                                                    /     *     |           \
                                                                                  /             |   *         \
                                                                                             .  |        .
                                                                                                |
                                                                                                |");
            Console.WriteLine(@"
              .                        .                        .                        .  
              |                        |                        |                        |  
     .               /         .               /         .               /         .               /   
      \       I                \       I              \       I                \       I    
                  /                       /                       /                       /
        \  ,g88R_           \  ,g88R_           \  ,g88R_           \  ,g88R_  
          d888(`  ).                   _          d888(`  ).               d888(`  ).                   _      d888(`  ).                   _  
 -  --==  888(     ).=--           .+(`  )`.  888(     ).=--           .+(`  )`.  888(     ).=--           .+(`  )`.  888(     ).=--           .+(`  )`.  
)         Y8P(       '`.          :(   .    ) Y8P(       '`.          :(   .    ) Y8P(       '`.          :(   .    ) Y8P(       '`.          :(   .    ) 
        .+(`(      .   )     .--  `.  (    ) ) .+(`(      .   )     .--  `.  (    ) ) .+(`(      .   )     .--  `.  (    ) ) .+(`(      .   )     .--  `. 
       ((    (..__.:'-'   .=(   )   ` _`  ) ) ((    (..__.:'-'   .=(   )   ` _`  ) ) ((    (..__.:'-'   .=(   )   ` _`  ) ) ((    (..__.:'-'   .=(   )   `
`.     `(       ) )       (   .  )     (   )  ._ `(       ) )       (   .  )     (   )  ._ `(       ) )       (   .  )     (   )  ._ `(       ) )       ( 
  )      ` __.:'   )     (   (   ))     `-'.:(`  )  ` __.:'   )     (   (   ))     `-'.:(`  )  ` __.:'   )     (   (   ))     `-'.:(`  )  ` __.:'   )     
)  )  ( )       --'       `- __.'         :(      )) ( )       --'       `- __.'         :(      )) ( )       --'       `- __.'         :(      )) ( )                                                  	
--..,___.--,--'`,---..-.--+--.,,-,,..._.--..-._.-a:f--.      --..,___.--,--'`,---..-.--+--.,,-,,..._.--..-._.-a:f--.      --..,___.--,--'`,---..-.--+--.,,");
            Console.ReadLine();
        fomenu:
            Console.Clear();
            Console.WriteLine(@"
              .                        .                        .                        .  
              |                        |                        |                        |  
     .               /         .               /         .               /         .               /   
      \       I                \       I              \       I                \       I    
                  /                       /                       /                       /
        \  ,g88R_           \  ,g88R_           \  ,g88R_           \  ,g88R_  
          d888(`  ).                   _          d888(`  ).                   _          d888(`  ).                   _          d888(`  ).                 
 -  --==  888(     ).=--           .+(`  )`.  888(     ).=--           .+(`  )`.  888(     ).=--           .+(`  )`.  888(     ).=--           .+(`  )`.  
)         Y8P(       '`.          :(   .    ) Y8P(       '`.          :(   .    ) Y8P(       '`.          :(   .    ) Y8P(       '`.          :(   .    ) 
        .+(`(      .   )     .--  `.  (    ) ) .+(`(      .   )     .--  `.  (    ) ) .+(`(      .   )     .--  `.  (    ) ) .+(`(      .   )     .--  `.  ( 
       ((    (..__.:'-'   .=(   )   ` _`  ) ) ((    (..__.:'-'   .=(   )   ` _`  ) ) ((    (..__.:'-'   .=(   )   ` _`  ) ) ((    (..__.:'-'   .=(   )   ` _`
`.     `(       ) )       (   .  )     (   )  ._ `(       ) )       (   .  )     (   )  ._ `(       ) )       (   .  )     (   )  ._ `(       ) )       (   .
  )      ` __.:'   )     (   (   ))     `-'.:(`  )  ` __.:'   )     (   (   ))     `-'.:(`  )  ` __.:'   )     (   (   ))     `-'.:(`  )  ` __.:'   )     (  
)  )  ( )       --'       `- __.'         :(      )) ( )       --'       `- __.'         :(      )) ( )       --'       `- __.'         :(      )) ( )       
.-'  (_.'          .')                    `(    )  )) (_.'          .')                    `(    )  )) (_.'          .')                    `(    )  )) (_.' 
                  (_  )                     ` __.:'              (_  )                     ` __.:'              (_  )                     ` __.:'              (_  )                                                             	
--..,___.--,--'`,---..-.--+--.,,-,,..._.--..-._.-a:f--.      --..,___.--,--'`,---..-.--+--.,,-,,..._.--..-._.-a:f--.      --..,___.--,--'`,---..-.--+--.,,-,,..._.--");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }


            string szoveg2 = "|| Üdvözzöllek A királyi kard Küldetés fő menüben ||";
            string szoveg3 = "|| Új Játék ||";
            string szoveg4 = "|| Történet ||";
            string szoveg5 = "|| Kilépés  || ";



            int konzolSzelesseg1 = Console.WindowWidth; // Konzolablak szélessége
            int balSzovegPozicio = (konzolSzelesseg1 - szoveg2.Length) / 2; // Középre igazítás

            Console.SetCursorPosition(balSzovegPozicio, Console.CursorTop); // Pozíció beállítása
            Console.WriteLine(szoveg2);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }

            int balSzovegPozicio1 = (konzolSzelesseg1 - szoveg3.Length) / 2;
            Console.SetCursorPosition(balSzovegPozicio1, Console.CursorTop);
            Console.WriteLine(szoveg3);


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
            int balSzovegPozicio2 = (konzolSzelesseg1 - szoveg4.Length) / 2;
            Console.SetCursorPosition(balSzovegPozicio1, Console.CursorTop);
            Console.WriteLine(szoveg4);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
            int balSzovegPozicio3 = (konzolSzelesseg1 - szoveg5.Length) / 2;
            Console.SetCursorPosition(balSzovegPozicio1, Console.CursorTop);
            Console.WriteLine(szoveg5);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
            for (int i = 0; i < 1; i++)
            {
                int Randomnumber = vszam.Next(idezetek.Length);
                string idezetszoveg = idezetek[Randomnumber];
                int balSzovegPozicio33 = (konzolSzelesseg1 - idezetszoveg.Length) / 2;
                Console.SetCursorPosition(balSzovegPozicio33, Console.CursorTop);
                Console.WriteLine(idezetszoveg);


            }
            Console.WriteLine();

            Console.Write("                                                       ||");

            string bemenet1 = Console.ReadLine();


            if (bemenet1.ToLower() == "új játék" || bemenet1.ToLower() == "uj jatek")
            {
                goto ujjatek;

            }
            else if (bemenet1.ToLower() == "történet" || bemenet1.ToLower() == "tortenet")
            {
                goto tortenet;
            }
            else if (bemenet1.ToLower() == "kilépés" || bemenet1.ToLower() == "kilepes")
            {
                Console.Clear();
                goto vege;
            }
            else
            {
                Console.Clear();
                goto fomenu;
            }
        //
        tortenet:
            Console.Clear();

            string[] jatekTortenet = {
                     "A barlang storya:\n" +
                      "Tele van felismerhetetlen szörnyekkel és teremtményekkel,\n" +
                     "de vigaszul a barlang legmélyebb pontján\n" +
                     "lehet Isabella királynő...",

                     "A barlang eredete:\n" +
                     "A barlang egy ogre vezér területe volt régen,\n" +
                     "mielőtt az emberek kiűzték onnan az ogrékat,\n" +
                     "és kibányászták az értékes érceket onnan.\n" +
                 "A bányászatok után ott hagyták az emberek,\n" +
                    "és egy elhagyatott bánya lett belőle.",

                    "Boss fight rész: Az Ogrelakhely\n" +
                      "A lovag végül eléri az ogre vezér szintjét,\n" +
                      "ahol egy hatalmas, kőből faragott trón áll.\n" +
                     "A levegő feszültséggel teli, és az egész hely érezhetően\n" +
                     "sötét és nyomasztó. Az ogre vezér már várt rá.\n" +
                     "A lovagnak itt kell szembenéznie az ogre vezér erejével.\n" +
                     "A harcban nemcsak a fizikai ereje,\n" +
                     "hanem az ügyessége, a harci képességei\n" +
                     "és a taktikai döntései is meghatározzák a küzdelmet.",

                     "A végső csata előtti feszültség:\n" +
                 "A lovag előtt áll az ogre vezér,\n" +
                     "és mindketten tudják, hogy csak\n" +
                    "az egyikük hagyhatja el élve ezt a helyet.",

                     "Boss Fight dialógusa:\n\n" +
                 "A hatalmas ogre vezér előtted áll,\n" +
                    "hatalmas fejszéje szikrázik\n" +
                    "a barlang sötét, füstös fényében.\n" +
                 "Isabella hercegnő melletted áll, de nem avatkozik közbe,\n" +
                 "csak figyel. A vezér mély, szörnyű hangon szólal meg:\n" +
                      "'Gyenge királyság! Az uralmuk már a végéhez ért.\n" +
                  "Most én fogok uralkodni!'",

                      "A vezér előre lép,\n" +
                      "és a fejszét felkészíti egy hatalmas csapásra.\n" +
                      "Te azonban tudod, hogy most nemcsak a fizikai erődet,\n" +
                      "hanem a stratégiádat is be kell vetned,\n" +
                      "ha győzni akarsz…",

                  "Zárás:\n\n" +
                  "A harcok után, ha a lovag legyőzi az ogre vezért,\n" +
              "a hercegnő hálásan segít eljutni a kijárathoz,\n" +
                  "miközben új szövetséget kötnek a királysággal.\n" +
                  "A szörnyek veresége után\n" +
                      "a királyi udvar visszanyeri a nyugalmát,\n" +
                     "de az ogre vezér halála nem biztos,\n" +
                         "hogy véget vetett minden fenyegetésnek…\n" +
                    "De ez már egy újabb történet kezdete lehet."
                        };


            Console.WriteLine(@"
A Goldberg Királyság Története:

A Goldberg Királyság egy hatalmas és gazdag birodalom,
amely évszázadokon keresztül uralta a kontinens legnagyobb részét.
A királyság szívét a Nagy Aranyváros képezi,
mely a királyi palota és a legnagyobb templomok otthona.
A város híres a fényűző aranyból készült épületeiről és a csillogó palotákról,
amelyek a hatalom és a jólét jelképei.
Az emberek hite és tisztelete a királyi család iránt határtalan,
mivel azt tartják, hogy az uralkodó vérvonal
A világ kezdetétől fogva isteni áldással bír.
A királyságot Király Alistair von Goldberg alapította
Több mint kétszáz évvel ezelőtt, egy elfeledett háború után,
mely a sötét varázslók és démonok seregeivel vívott harcokban egyesítette a földet.
Az ő vezetésével sikerült legyőzniük a sötétséget,
és egyesíteniük a különböző népeket és törzseket,
akik ma Goldberg népét alkotják.
A királyi család hatalma azóta sem csökkent, és a királyság virágzik.
                                                                                                                                                ,--,  ,.-.
                                                                                                                   ,                   \,       '-,-`,'-.' | ._
                                                                                                                  /|           \    ,   |\         }  )/  / `-,',
                                                                                                                  [ ,          |\  /|   | |        /  \|  |/`  ,`
                                                                                                                  | |       ,.`  `,` `, | |  _,...(   (      .',
                                                                                                                  \  \  __ ,-` `  ,  , `/ |,'      Y     (   /_L\
                                                                                                                   \  \_\,``,   ` , ,  /  |         )         _,/
                                                                                                                    \  '  `  ,_ _`_,-,<._.<        /         /
                                                                                                                     ', `>.,`  `  `   ,., |_      |         /
                                                                                                                       \/`  `,   `   ,`  | /__,.-`    _,   `\
                                                                                                                   -,-..\  _  \  `  /  ,  / `._) _,-\`       \
                                                                                                                    \_,,.) /\    ` /  / ) (-,, ``    ,        |
                                                                                                                   ,` )  | \_\       '-`  |  `(               \
                                                                                                                  /  /```(   , --, ,' \   |`<`    ,            |
                                                                                                                 /  /_,--`\   <\  V /> ,` )<_/)  | \      _____)
                                                                                                           ,-, ,`   `   (_,\ \    |   /) / __/  /   `----`
                                                                                                          (-, \           ) \ ('_.-._)/ /,`    /
                                                                                                          | /  `          `/ \\ V   V, /`     /
                                                                                                       ,--\(        ,     <_/`\\     ||      /
                                                                                                      (   ,``-     \/|         \-A.A-`|     /
                                                                                                     ,>,_ )_,..(    )\          -,,_-`  _--`
                                                                                                    (_ \|`   _,/_  /  \_            ,--`
                                                                                                     \( `   <.,../`     `-.._   _,-`
A királyság gazdagságát és hatalmát
A híres Aranybányák és az Ezüstföldek biztosítják
amelyek mélyen a föld alatt húzódnak.
A Mágikus Árnyékhegyek mélyén lévő bányák
különleges varázslatos kincseket is tartalmaznak
amelyek aranyat, ezüstöt és ritka mágikus anyagokat adnak.
A királyi család a bányák birtoklásával
És az ezekből származó erőforrásokkal képes fenntartani
A hatalmát és a hadseregét.

Goldberg édesapja egy maroknyi arany éremel engedte útnak a fiát!

A Királyság Titkai:
Bár a királyság nagysága és gazdagsága mindenki előtt ismert
Nem mindenki tudja, hogy Goldbergnek van egy sötét titka.
A Védelmezők Rendje, amely a királyi család titkos védelmezői,
több évszázadon keresztül dolgoztak azon,
hogy egy ősi mágia titkait elrejtve tartják a világ elől.
A királyi család ereje és hatalma valójában
egy titkos mágikus szövetségen alapul,
amelyet a Szilánkok Szent Grálja ad.
Ez a mágiát adó tárgy egy ősi varázsló, Veldorin, titkos alkotása,
amely egy sötét rituáléval jött létre.
A legenda szerint a Grál tartalmaz egy ősi varázslatot,
amely képes fenntartani a királyi család hatalmát,
de minden egyes felhasználásával,
egyre sötétebb és veszélyesebb erőket ébreszt.

");

            Console.WriteLine(jatekTortenet[0]);
            Console.WriteLine();
            Console.WriteLine(jatekTortenet[1]);
            Console.WriteLine();






            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("Vissza szertnél lépni a történet oldalról? IGEN | NEM");

            string bemenet2 = Console.ReadLine();
            if (bemenet2.ToLower() == "igen")
            {
                Console.Clear();
                goto fomenu;

            }
            else
            {
                Console.Clear();
                goto tortenet;
            }
        ujjatek:


            Console.Clear();
            int konzolSzelesseg2 = Console.WindowWidth;
            string ujjatekszoveg1 = "Üdvözöllek A királyi kard Küldetésén!";


            string jatekosNev;

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }

            int balSzovegPozicioujjatek1 = (konzolSzelesseg2 - ujjatekszoveg1.Length) / 2;
            Console.SetCursorPosition(balSzovegPozicioujjatek1, Console.CursorTop);
            Console.WriteLine(ujjatekszoveg1);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
            }

            Console.Write("Kérlek add meg a játékos neved: ");
            jatekosNev = Console.ReadLine();

            Console.Clear();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }

            int balSzovegPozicioujjatek2 = (konzolSzelesseg2 - ujjatekszoveg1.Length) / 2;
            Console.SetCursorPosition(balSzovegPozicioujjatek2, Console.CursorTop);
            Console.WriteLine(ujjatekszoveg1);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }
            string ujjatekszoveg3 = $"{jatekosNev} nagy hatalmú családból származik, amely nagy keleti kontinens uralkodója.";
            int balSzovegPozicioujjatek4 = (konzolSzelesseg2 - ujjatekszoveg3.Length) / 2;
            Console.SetCursorPosition(balSzovegPozicioujjatek4, Console.CursorTop);
            Console.WriteLine(ujjatekszoveg3);

            string ujjatekszoveg2 = $"{jatekosNev} Goldberg édesapja oda adta a királyi kardot hogy megmentse a királynőt.";

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }
            int balSzovegPozicioujjatek3 = (konzolSzelesseg2 - ujjatekszoveg2.Length) / 2;
            Console.SetCursorPosition(balSzovegPozicioujjatek3, Console.CursorTop);
            Console.WriteLine(ujjatekszoveg2);
            Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine($"Isabella királynő útnak indult, hogy meglátogassa a Goldberg Királyságot.\n Azonban egy jól szervezett rajtaütés áldozatává vált, és a szörnyek fogságába esett.\n A támadók valószínűleg a hírhedt északi hegyekbe hurcolták őt.\n{jatekosNev} Goldberg, amint értesült a történtekről, habozás nélkül a nyomukba eredt, hogy kiszabadítsa a királynőt.");




            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(@"


















                       _                                                                               _
                      /#\                                                                             /#\
                     /###\     /\                                                                    /###\     /\
                    /  ###\   /##\  /\                                                              /  ###\   /##\  /\
                   /      #\ /####\/##\                                                            /      #\ /####\/##\
                  /  /      /   # /  ##\             _       /\                                   /  /      /   # /  ##\             _       /\
                // //  /\  /    _/  /  #\ _         /#\    _/##\    /\                          // //  /\  /    _/  /  #\ _         /#\    _/##\  
               // /   /  \     /   /    #\ \      _/###\_ /   ##\__/ _\                        // /   /  \     /   /    #\ \      _/###\_ /   ##\_
              /  \   / .. \   / /   _   { \ \   _/       / //    /    \\                       /  \   / .. \   / /   _   { \ \   _/       / //   |
             /    /\  ...  \_/   / / \   } \ | /  /\  \ /  _    /  /    \ /\      /\     /    /\  ...  \_/   / / \   } \ | /  /\  \ /  _    /  / | 
           /// / .\  ..%:.  /... /\ . \ {:  \\   /. \     / \  /   ___   /  \  _ /  \  /// / .\  ..%:.  /... /\ . \ {:  \\   /. \     / \  /   __|
          // \/... \.::::..... _/..\ ..\:|:. .  / .. \\  /.. \    /...\ /  \ \ /.\ .\.\// \/... \.::::..... _/..\ ..\:|:. .  / .. \\  /.. \    /..
          ..:.\. ..:::::::..:..... . ...\{:... / %... \\/..%. \  /./:..\__   \/...\.../..:.\. ..:::::::..:..... . ...\{:... / %... \\/..%. \  /./:
          :::....:::;;;;;;::::::::.:::::.\}.....::%.:. \ .:::. \/.%:::.:..\ .:..\:..:::....:::;;;;;;::::::::.:::::.\}.....::%.:. \ .:::. \/.%:::.:
          :;;:::::;;;;;;;;;;;;;;:::::;;::{:::::::;;;:..  .:;:... ::;;::::..::::...:::;;:::::;;;;;;;;;;;;;;:::::;;::{:::::::;;;:..  .:;:... ::;;:::
          ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;];;;;;;;;;;::::::;;;;:.::;;;;;;;;:..;;;;:::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;];;;;;;;;;;::::::;;;;:.::;;
          ;;;;;ii;;;;;;;;;;;;;;;;;;;;;;;;[;;;;;;;;;;;;;;;;;;;;;;:;;;;;;;;;;;;;;;;;;;;;;;;;;;ii;;;;;;;;;;;;;;;;;;;;;;;;[;;;;;;;;;;;;;;;;;;;;;;:;;;;
          ;;;;;;;;;;iiiiiiii;;;;;;;;;;;;;;};;ii;;iiii;;;;i;;;;;;;;;;;;;;;ii;;;;;;;;;;;;;;;;;;;;;;iiiiiiii;;;;;;;;;;;;;;};;ii;;iiii;;;;i;;;;;;;;;;;
          iiiiiiiiIIIIIIIIIIIiiiiiIiiiiii{iiIIiiiiiiiiiiiiiiii;;;;;iiiilliiiiii ii;;;iiiiiiiiiiIIIIIIIIIIIiiiiiIiiiiii{iiIIiiiiiiiiiiiiiiii;;;;;ii
          llllIIlllIIIIlllIIIlIiiIIIIIIIIIIIIlIIIIIllIIIIIIIIiiiiiiiillIIIllII   iiIIllllllIIlllIIIIlllIIIlIiiIIIIIIIIIIIIlIIIIIllIIIIIIIIiiiiiiii
          IIIIIllTIIIIllIIlIlIIITTTTlIlIlIIIlIITTTTTTTIIIIlIIllIlIlllIIIIIIITT   iiilIIIIIIIllTIIIIllIIlIlIIITTTTlIlIlIIIlIITTTTTTTIIIIlIIllIlIlll
          IITTTTTTTIIIIIIIIIIIIITTTTTIIIIIIIIITTTTTTTTTTIIIIIIIIIlIIIIIIIITTT     ilIIIIITTTTTTTIIIIIIIIIIIIITTTTTIIIIIIIIITTTTTTTTTTIIIIIIIIIlIII
          TTTTTTTTTTTTTIIIIIIIITTTTTTTTIIIIIITTTTTTTTTTTTTTIIIIIIIIIIIIIITTTT     IIIITTTTTTTTTTTTTIIIIIIIITTTTTTTTIIIIIITTTTTTTTTTTTTTIIIIIIIIIII
        ");
            Console.ReadLine();
            Console.WriteLine();
            Console.Clear();
            goto mainMenu;

        mainMenu:
            Console.Clear();
            Console.WriteLine(@"




                                                                   (                 ,&&&.
                                                                    )                .,.&&
                                                                   (  (              \=__/ 
                                                                       )             ,'-'. 
                                                                 (    (  ,,      _.__|/ /| 
                                                                  ) /\ -((------((_|___/ | 
                                                                (  // | (`'      ((  `'--| 
                                                              _ -.;_/ \\--._      \\ \\-._/. 
                                                             (_;-// | \\ \\-'.\\    <_,\\_\\`--'| 
                                                             ( `.__ _  ___,')      <_,-'__,'
                                                              `'(_ )_)(_)_)' ");
            Console.WriteLine();



            int konzolSzelesseg3 = Console.WindowWidth;

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }
            string mainJatekSzoveg1 = "Jelenleg egy tábortűz mellett ülsz!";
            int balSzovegPozicioujjatek5 = (konzolSzelesseg3 - mainJatekSzoveg1.Length) / 2;
            Console.SetCursorPosition(balSzovegPozicioujjatek5, Console.CursorTop);
            Console.WriteLine(mainJatekSzoveg1);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine();
            Console.WriteLine($"{waveCounter * 100} méter mélyen tartózkodik {jatekosNev} Goldberg.");
            Console.WriteLine($"{jatekosNev} Goldberg a tábortűz mellett tud megpihenni és felkészülni a harcra!");

            Console.Write("A hátitáskád tartalma: ");
            foreach (var elem in jatekosHatitaska)
            {
                Console.Write("|" + elem + "");
            }
            Console.Write("");
            Console.WriteLine();
            Console.WriteLine($"Tapasztalati szint: {jatekosExpLVL}.");
            Console.WriteLine($"Pénztárca: {jatekosPenztarca} arany érem.                                                         ");
            Console.WriteLine($"{jatekosNev} Goldberg sebzése: {Math.Round(jatekosStatja[1])} + {Math.Round(jatekosKardSebzes[0])} * {jatekosKardSebzes[1] + 1} = {jatekosStatja[1] + jatekosKardSebzes[0] * (jatekosKardSebzes[1] + 1)} ");
            Console.WriteLine($"{jatekosNev} Goldberg életereje: {Math.Round(jatekosStatja[0] + jatekosPancelEletero[0])}");
            Console.WriteLine();
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine();
            Console.WriteLine("                                                                  |Bolt| | |Játék folytatás| | |Menü|");
            Console.WriteLine();
            Console.Write($"                                                                  {jatekosNev}:");
            string mainmenu1 = Console.ReadLine();  // bolt|fojatek|menu

            if (mainmenu1.ToLower() == "bolt")
            {
                Console.Clear();
                goto bolt;

            }
            else if (mainmenu1.ToLower() == "Játék folytatás" || mainmenu1.ToLower() == "jatek folytatas")
            {
                Console.Clear();
                goto fojatek;
            }
            else if (mainmenu1.ToLower() == "menü" || mainmenu1.ToLower() == "menu")
            {
                Console.Clear();
                goto fomenu;
            }
            else
            {
                Console.Clear();
                goto mainMenu;
            }
        ///////////////////////////////Bolt///////////////////////////////////////////
        ///////////////////////////////Bolt///////////////////////////////////////////
        ///////////////////////////////Bolt//////////////////////////////////////////
        ///
        bolt:

            Console.Clear();
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine(@"
                                                                   .eec.                 .e$$$c                                
                                                                  z$*''''*$$eec..       zP  .3$c **              
                                                                 .$''''  d$''''''''''****bee*=*''*$                                
                                                                 $%  d$$                 ^$%  d$$                          
                                                                .$  z$%$bc.            .$  z$%$bc.                          
                                                                4F 4$'''' $''''^$*ec...ee.    ./' b                             
                                                                dF $P  P  F   ''''''3F''''''''   4**                             
                                                                3b4$   ''''           $F         4 **                            
                                                                4$$$  -            $F        4   $F                            
                                                                 $$$               $F        4   $$$                         
                                                                 *$$               $F        @   $$*                         
                                                                 4$$               $F        F   4$$                         
                                                                 ^$F   .......     $F       .F   $F                           
                                                                  $''''  z''''     ^''''''$F''''''%.                            
                                                                 4$  4F     e      $L          ''''.                           
                                                                 4F  ^L    4$     z%''''c    *.    b                           
                                                                 d    ^$*=e$$eer=$'''$*=e$$eer=$..e*                           
                                                                 $     $   $F    $   zP  4P    F   4%                          
                                                                 F     F   $F    4. .P   d%    J    $                         
                                                                4%     F   $F     F $   $F    zP    J                            
                                                                J      F   '%     Fd'   $F    4P    $                             
                                                                $      F          $F    $F    P    J                          
                                                                $      L         .$          4%   4%                           
                                                                *      '.       .$$.       .$   4%                           
                                                                '       ^''''****''''*******$'' $                              
                                                                 %                        .P   $                              
                                                                  *c                     .@ $                                
                                                                   ^''''%4c...        ...* '                         
                                                                             ^''''''''");
            Console.ReadLine();
            Console.Clear();
            int konzolSzelesseg4 = Console.WindowWidth;
            int db = 1;
            int db1 = 1;
            string boltszoveg1 = "Üdvözöllek a boltban!";
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }
            int balSzovegPozicioBolt1 = (konzolSzelesseg4 - boltszoveg1.Length) / 2;
            Console.SetCursorPosition(balSzovegPozicioBolt1, Console.CursorTop);
            Console.WriteLine(boltszoveg1);
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }
            // { }
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("A boltban ásványok találhatóak amik a felszerelést fejleszti legyen az kard vagy páncél! ");
            Console.WriteLine($"Jelenleg ennyi életerőd van {jatekosStatja[0]} + a pancél {jatekosPancelEletero[0]}.");
            Console.WriteLine($"Jelenleg ennyi sebzésed van {jatekosStatja[1]} + a kard {jatekosKardSebzes[0]} + a kritikus sebzés {jatekosKardSebzes[1]}");
            Console.WriteLine($"Pénztárcád: {jatekosPenztarca}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("Szeretnél szerencsét próbálni? 10 arany érem egy láda... IGEN | | | NEM");


            //Bolt láda nyitás | Véletszám | vszam

            string boltDontes3 = Console.ReadLine();
            if (boltDontes3.ToLower() == "igen")
            {
                Console.WriteLine("Milyen ásványt szeretnél nyitni? KARD | PÁNCÉL");
                string boltDontes4 = Console.ReadLine();
                if (boltDontes4.ToLower() == "kard")
                {

                    Console.WriteLine("A kard fejlesztéshez szükséges ásványok nevei:");
                    foreach (var item in boltKardAsvany)
                    {
                        Console.WriteLine($"{db,4}. {item,4}.");
                        db++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Biztosan nyitni szeretnél egy ládát ? IGEN | NEM");
                    string boltDontes5 = Console.ReadLine();
                    if (boltDontes5.ToLower() == "igen" && jatekosPenztarca >= 10)
                    {
                        jatekosPenztarca = jatekosPenztarca - 10;
                        int generaltszam = 0;
                        for (int i = 0; i < 1; i++)
                        {
                            int randomNumber = vszam.Next(0, 101);
                            Console.WriteLine($"{randomNumber}. számot nyitottál.");
                            generaltszam = randomNumber;
                        }
                        // <  > int[] jatekosStatja = { 300, 50 };
                        //      double[] jatekosKardSebzes = { 0, 0 };
                        if (generaltszam <= 22)
                        {
                            // 1. Tűzfény Kristály – 20% (0-20): 5 sebzés
                            Console.WriteLine("");
                            Console.WriteLine("1. Tűzfény Kristály – 20% (0-20): +5 sebzés | +0.05 kritikus sebzés");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosKardSebzes[1] = 0.05;
                                jatekosKardSebzes[0] = 5;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }

                        }
                        else if (generaltszam <= 37)
                        {
                            // 2. Kék Árnyék Kő – 15% (21-35): 10 sebzés
                            Console.WriteLine("");
                            Console.WriteLine("2. Kék Árnyék Kő – 15% (21-35): 10 sebzés |0.1 kritikus sebzés");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosKardSebzes[1] = 0.1;
                                jatekosKardSebzes[0] = 10;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }

                        }
                        else if (generaltszam <= 50)
                        {
                            // 3. Mosszöld Obszidián – 13% (36-48): 15 sebzés
                            Console.WriteLine("");
                            Console.WriteLine("3. Mosszöld Obszidián – 13% (36-48): 15 sebzés |0.15 kritikus sebzés");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosKardSebzes[1] = 0.15;
                                jatekosKardSebzes[0] = 15;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 62)
                        {
                            // 4. Ezüst Holdkő – 12% (49-60): 20 sebzés
                            Console.WriteLine("");
                            Console.WriteLine("4. Ezüst Holdkő – 12% (49-60): 20 sebzés | 0.2 kritikus sebzés");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosKardSebzes[1] = 0.2;
                                jatekosKardSebzes[0] = 20;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 70)
                        {
                            // 5. Lángoló Zafír – 8% (61-68): 30 sebzés
                            Console.WriteLine("");
                            Console.WriteLine("5. Lángoló Zafír – 8% (61-68): 30 sebzés | 0.3 kritikus sebzés");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosKardSebzes[1] = 0.3;
                                jatekosKardSebzes[0] = 30;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 77)
                        {
                            // 6. Pókfonál Kő – 7% (69-75): 35 sebzés
                            Console.WriteLine("");
                            Console.WriteLine("6. Pókfonál Kő – 7% (69-75): 35 sebzés | 0.35 kritikus sebzés");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosKardSebzes[1] = 0.35;
                                jatekosKardSebzes[0] = 35;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 83)
                        {
                            // 7. Éjfél Tűz Kő – 6% (76-81): 40 sebzés
                            Console.WriteLine("");
                            Console.WriteLine("7. Éjfél Tűz Kő – 6% (76-81): +40 sebzés | +0.4% kritikus");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosKardSebzes[1] = 0.4;
                                jatekosKardSebzes[0] = 40;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 91)
                        {
                            // 8. Fagyott Lúdtoll Kristály – 8% (82-89): 50 sebzés
                            Console.WriteLine("");
                            Console.WriteLine("8. Fagyott Lúdtoll Kristály – 8% (82-89): 50 sebzés | 0.5 kritikus sebzés");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosKardSebzes[1] = 0.5;
                                jatekosKardSebzes[0] = 50;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 97)
                        {
                            // 9. Vihar Lángja – 6% (90-95): 60 sebzés
                            Console.WriteLine("");
                            Console.WriteLine("9. Vihar Lángja – 6% (90-95): 60 sebzés | 0.6 kritikus sebzés");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosKardSebzes[1] = 0.6;
                                jatekosKardSebzes[0] = 60;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Ősi Csillagfény – 4% (96-100): 80 sebzés | 0.8 kritikus sebzés");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosKardSebzes[1] = 0.8;
                                jatekosKardSebzes[0] = 80;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }




                    }
                    else
                    {
                        Console.WriteLine("Rendben.");
                        Console.ReadLine();
                        goto bolt;
                    }
                }
                else if (boltDontes4.ToLower() == "páncél" || boltDontes4.ToLower() == "pancel")
                {

                    Console.WriteLine("A kard fejlesztéshez szükséges ásványok nevei:");
                    foreach (var item in boltPancelAsvany)
                    {
                        Console.WriteLine($"{db,4}. {item,4}.");
                        db++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Biztosan nyitni szeretnél egy ládát ? IGEN | NEM");
                    string boltDontes5 = Console.ReadLine();
                    if (boltDontes5.ToLower() == "igen" && jatekosPenztarca >= 10)
                    {
                        jatekosPenztarca = jatekosPenztarca - 10;
                        int generaltszam = 0;
                        for (int i = 0; i < 1; i++)
                        {
                            int randomNumber = vszam.Next(0, 101);
                            Console.WriteLine($"{randomNumber}. számot nyitottál.");
                            generaltszam = randomNumber;
                        }
                        // <  > int[] jatekosStatja = { 300, 50 };
                        //      double[] jatekosKardSebzes = { 0, 0 };
                        if (generaltszam <= 22)
                        {
                            // 1. Fénytörő Obszidián – 20% (0-20): 50 életerő 0.05
                            Console.WriteLine("");
                            Console.WriteLine("1. Fénytörő Obszidián – 20% (0-20): 50 életerő");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosPancelEletero[0] = 50;

                                Console.Clear();
                                goto bolt;
                            }//boltKardAsvany jatekosPancelEletero
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }

                        }
                        else if (generaltszam <= 37)
                        {
                            // 2. Vérvörös Jaspis – 15% (21-35): 100 életerő 0.1
                            Console.WriteLine("");
                            Console.WriteLine("2. Vérvörös Jaspis – 15% (21-35): 100 életerő");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosPancelEletero[0] = 100;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }

                        }
                        else if (generaltszam <= 50)
                        {
                            // 3. Holdfény Amatészter – 13% (36-48): 150 életerő 0.15
                            Console.WriteLine("");
                            Console.WriteLine("3. Holdfény Amatészter – 13% (36-48): 150 életerő");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosPancelEletero[0] = 150;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 62)
                        {
                            // 4. Ékkő Tükrözült – 12% (49-60): 200 életerő 0.20
                            Console.WriteLine("");
                            Console.WriteLine("4. Ékkő Tükrözült – 12% (49-60): 200 életerő");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosPancelEletero[0] = 200;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 70)
                        {
                            // 5. Fekete Szivárvány – 8% (61-68): 250 életerő 0.25
                            Console.WriteLine("");
                            Console.WriteLine("5. Fekete Szivárvány – 8% (61-68): 250 életerő");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosPancelEletero[0] = 250;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 77)
                        {
                            // 6. Tűzvirág Kristály – 7% (69-75): 300 életerő 0.30
                            Console.WriteLine("");
                            Console.WriteLine("6. Tűzvirág Kristály – 7% (69-75): 300 életerő");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosPancelEletero[0] = 300;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 83)
                        {
                            // 7. Víz Tükörkő – 6% (76-81): 350 életerő 0.35
                            Console.WriteLine("");
                            Console.WriteLine("7. Víz Tükörkő – 6% (76-81): 350 életerő");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosPancelEletero[0] = 350;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 91)
                        {
                            // 8. Csontfehér Kő – 8% (82-89): 400 életerő 0.40
                            Console.WriteLine("");
                            Console.WriteLine("8. Csontfehér Kő – 8% (82-89): 400 életerő");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosPancelEletero[0] = 400;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else if (generaltszam <= 97)
                        {
                            // 9. Zöld Fény Kristály – 6% (90-95): 500 életerő 0.50
                            Console.WriteLine("");
                            Console.WriteLine("9. Zöld Fény Kristály – 6% (90-95): 500 életerő");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosPancelEletero[0] = 500;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }
                        else
                        {
                            // 10. Fekete Holdkő – 4% (96-100): 600 életerő 0.60
                            Console.WriteLine("");
                            Console.WriteLine("10. Fekete Holdkő – 4% (96-100): 600 életerő");
                            Console.WriteLine("");
                            Console.WriteLine("Biztosan meg szertnéd tartani? IGEN | NEM");
                            string boltValasz1 = Console.ReadLine();
                            if (boltValasz1.ToLower() == "igen")
                            {
                                jatekosPancelEletero[0] = 600;
                                Console.Clear();
                                goto bolt;
                            }
                            else
                            {
                                Console.Clear();
                                goto bolt;
                            }
                        }






                    }
                    else
                    {
                        Console.WriteLine("Rendben.");
                        Console.ReadLine();
                        goto bolt;
                    }


                }


            }
            else if (boltDontes3.ToLower() == "nem")
            {
                Console.WriteLine("Rendben, vissza térsz a tábortűzhöz!");
                Console.ReadLine();
                Console.Clear();
                goto mainMenu;
            }
            else if (boltDontes3.ToLower() == "tartalom")
            {
                Console.WriteLine("A kard fejlesztéshez szükséges ásványok nevei:");
                foreach (var item in boltKardAsvany)
                {
                    Console.WriteLine($"{db,4}. {item,4}.");
                    db++;
                }
                Console.WriteLine();
                Console.WriteLine("A páncél fejlesztéshez szükséges ásványok nevei:");
                foreach (var item in boltKardAsvany)
                {
                    Console.WriteLine($"{db1,4}. {item,4}.");
                    db1++;
                }
                Console.WriteLine();
                Console.ReadLine();
                Console.Clear();
                goto bolt;
            }
            else
            {
                goto bolt;
            }














        fojatek:


            var CsataJatekosEleteroStatja = jatekosPancelEletero[0] + jatekosStatja[0];
            var CsataJatekosSebzesStatja = jatekosKardSebzes[0];
            var CsataJatekosKritikusSebzes = jatekosKardSebzes[1];
            var CsataJatekosSebzesStatjaVégleges = jatekosKardSebzes[0] * jatekosKardSebzes[1];
            var CsataMobEletero = mobokStatja[0] * 3;
            var CsataMobSebzes = mobokStatja[1] * 3;
            var CsataMobMiniBossEletero = mobMiniBoss[0];
            var CsataMobMiniBossSebzes = mobMiniBoss[1];
            var CsataMobFinalBossEletero = mobFinalBoss[0];
            var CsataMobFinalBossSebzes = mobFinalBoss[1];
            Console.Clear();


            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($"A barlang {waveCounter * 100}m mélyen tartozkodól jelenleg.De mélyebbre merészkedel a királynőt megtalálni.");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine();

            Console.ReadLine();
            if (waveCounter % 5 == 0 || waveCounter % 10 == 0)
            {
                if (waveCounter == 5 || waveCounter == 15 || waveCounter == 25 || waveCounter == 35 || waveCounter == 45)//Miniboss
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("Ogréval Küzdesz!");
                    Console.WriteLine("Egy gonosz Ogre rátámad a játékosra!");
                    Console.WriteLine("----------------------------------------------------------");

                    bool jatekKimenet = false;
                    CsataJatekosEleteroStatja = jatekosPancelEletero[0] + jatekosStatja[0];
                    CsataJatekosSebzesStatja = jatekosStatja[1] + jatekosKardSebzes[0];
                    CsataJatekosKritikusSebzes = 0;
                    CsataMobMiniBossEletero = mobMiniBoss[0];
                    CsataMobMiniBossSebzes = mobMiniBoss[1];
                    double CsataJatekosSebzesStatjaVégleges2 = 0;
                    Console.WriteLine(@"
                                                                                                                  /|
                                                                                                                 |\|
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                              ~-[{o}]-~
                                                                                                                 |/|
                                                                                                                 |/|
                                                                                         ///~`     |\\_          `0'         =\\\\         . .
                                                                                        ,  |='  ,))\_| ~-_                    _)  \      _/_/|
                                                                                       / ,' ,;((((((    ~ \                  `~~~\-~-_ /~ (_/\ 
                                                                                     /' -~/~)))))))'\_   _/'                      \_  /'  D   |
                                                                                    (       (((((( ~-/ ~-/                          ~-;  /    \--_
                                                                                     ~~--|   ))''    ')  `                            `~~\_    \   )
                                                                                         :        (_  ~\           ,                    /~~-     ./
                                                                                          \        \_   )--__  /(_/)                   |    )    )|
                                                                                ___       |_     \__/~-__    ~~   ,'      /,_;,   __--(   _/      |
                                                                              //~~\`\    /' ~~~----|     ~~~~~~~~'        \-  ((~~    __-~        |
                                                                            ((()   `\`\_(_     _-~~-\                      ``~~ ~~~~~~   \_      /
                                                                             )))     ~----'   /      \                                   )       )
                                                                              (         ;`~--'        :                                _-    ,;;(
                                                                                        |    `\       |                             _-~    ,;;;;)
                                                                                        |    /'`\     ;                          _-~          _/
                                                                                       /~   /    |    )                         /;;;''  ,;;:-~
                                                                                      |    /     / | /                         |;;'   ,''
                                                                                      /   /     |  \\|                         |   ,;(    
                                                                                    _/  /'       \  \_)                   .---__\_    \,--._______
                                                                                   ( )|'         (~-_|                   (;;'  ;;;~~~/' `;;|  `;;;\
                                                                                    ) `\_         |-_;;--__               ~~~----__/'    /'_______/
                                                                                    `----'       (   `~--_ ~~~;;------------~~~~~ ;;;'_/'
                                                                                                 `~~~~~~~~'~~~-----....___;;;____---~~");
                    while (!jatekKimenet)  // A játék addig folytatódik, amíg valaki el nem fogy
                    {
                        if (CsataMobMiniBossEletero <= 0)
                        {
                            Console.WriteLine("-------------------------------------------------------");
                            Console.WriteLine("A játékos megnyerte a csatát! Továbbhaladhatsz.");
                            Console.WriteLine("-------------------------------------------------------");
                            Console.ReadLine();
                            waveCounter++;
                            Console.Clear();

                            mobMiniBoss[0] = mobMiniBoss[0] * 1.6;
                            mobMiniBoss[1] = mobMiniBoss[1] * 1.6;
                            jatekosStatja[0] = jatekosStatja[0] * 1.10;
                            jatekosStatja[1] = jatekosStatja[1] * 1.10;
                            jatekosPenztarca += 50;
                            jatekosExpLVL++;
                            goto mainMenu;
                            jatekKimenet = true;
                        }
                        else if (CsataJatekosEleteroStatja <= 0)
                        {
                            Console.WriteLine("-------------------------------------------------------");
                            Console.WriteLine("A játékos elbukta a csatát. A játéknak vége!");
                            Console.WriteLine("-------------------------------------------------------");
                            Console.ReadLine();
                            Console.Clear();

                            jatekKimenet = true;
                        }
                        else
                        {
                            for (int i = 0; i < 1; i++)
                            {
                                int randomNumber = vszam.Next(1, 3);
                                if (randomNumber == 1)
                                {
                                    CsataJatekosSebzesStatjaVégleges2 = (1 + jatekosKardSebzes[1]) * jatekosKardSebzes[0] + jatekosStatja[1];
                                }
                                else
                                {
                                    CsataJatekosSebzesStatjaVégleges2 = jatekosKardSebzes[0] + jatekosStatja[1];
                                }
                            }




                            Console.WriteLine("-------------------------------------------------------");

                            // A játékos támad először
                            Console.WriteLine($"A játékos támad! Az Ogre {Math.Round(CsataJatekosSebzesStatjaVégleges2)} életerőt veszít.");
                            CsataMobMiniBossEletero -= CsataJatekosSebzesStatjaVégleges2;

                            // Ha a goblinok túlélik, akkor támadnak vissza
                            if (CsataMobEletero > 0)
                            {
                                Console.WriteLine($"Az Ogre visszatámad! A játékos {Math.Round(CsataMobSebzes)} életerőt veszít.");
                                CsataJatekosEleteroStatja -= CsataMobMiniBossSebzes;
                            }

                            Console.WriteLine($"Játékos Életerő: {Math.Round(CsataJatekosEleteroStatja)}");
                            Console.WriteLine($"Ogre életereje: {Math.Round(CsataMobMiniBossEletero)}");
                            Console.WriteLine("-------------------------------------------------------");


                            Console.ReadLine(); // Léptetés a következő körre
                        }
                    }

                }
                else//Final boss minden tizedik wave
                {

                    Console.Clear();

                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("Trollal Küzdesz!");
                    Console.WriteLine("Egy gonosz troll rátámad a játékosra!");
                    Console.WriteLine("----------------------------------------------------------");

                    bool jatekKimenet = false;
                    CsataJatekosEleteroStatja = jatekosPancelEletero[0] + jatekosStatja[0];
                    CsataJatekosSebzesStatja = jatekosStatja[1] + jatekosKardSebzes[0];
                    CsataJatekosKritikusSebzes = 0;
                    CsataMobFinalBossEletero = mobFinalBoss[0];
                    CsataMobFinalBossSebzes = mobFinalBoss[1];
                    double CsataJatekosSebzesStatjaVégleges2 = 0;
                    Console.WriteLine(@"
                                                                                                                  /|
                                                                                                                 |\|
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                              ~-[{o}]-~
                                                                                                                 |/|
                                                                                                                 |/|
                                                                                         ///~`     |\\_          `0'         =\\\\         . .
                                                                                        ,  |='  ,))\_| ~-_                    _)  \      _/_/|
                                                                                       / ,' ,;((((((    ~ \                  `~~~\-~-_ /~ (_/\ 
                                                                                     /' -~/~)))))))'\_   _/'                      \_  /'  D   |
                                                                                    (       (((((( ~-/ ~-/                          ~-;  /    \--_
                                                                                     ~~--|   ))''    ')  `                            `~~\_    \   )
                                                                                         :        (_  ~\           ,                    /~~-     ./
                                                                                          \        \_   )--__  /(_/)                   |    )    )|
                                                                                ___       |_     \__/~-__    ~~   ,'      /,_;,   __--(   _/      |
                                                                              //~~\`\    /' ~~~----|     ~~~~~~~~'        \-  ((~~    __-~        |
                                                                            ((()   `\`\_(_     _-~~-\                      ``~~ ~~~~~~   \_      /
                                                                             )))     ~----'   /      \                                   )       )
                                                                              (         ;`~--'        :                                _-    ,;;(
                                                                                        |    `\       |                             _-~    ,;;;;)
                                                                                        |    /'`\     ;                          _-~          _/
                                                                                       /~   /    |    )                         /;;;''  ,;;:-~
                                                                                      |    /     / | /                         |;;'   ,''
                                                                                      /   /     |  \\|                         |   ,;(   
                                                                                    _/  /'       \  \_)                   .---__\_    \,--._______
                                                                                   ( )|'         (~-_|                   (;;'  ;;;~~~/' `;;|  `;;;\
                                                                                    ) `\_         |-_;;--__               ~~~----__/'    /'_______/
                                                                                    `----'       (   `~--_ ~~~;;------------~~~~~ ;;;'_/'
                                                                                                 `~~~~~~~~'~~~-----....___;;;____---~~");
                    while (!jatekKimenet)  // A játék addig folytatódik, amíg valaki el nem fogy
                    {
                        if (CsataMobFinalBossEletero <= 0)
                        {
                            Console.WriteLine("-------------------------------------------------------");
                            Console.WriteLine("A játékos megnyerte a csatát! Továbbhaladhatsz.");
                            Console.WriteLine("-------------------------------------------------------");
                            Console.ReadLine();
                            waveCounter++;
                            Console.Clear();

                            mobMiniBoss[0] = mobMiniBoss[0] * 1.6;
                            mobMiniBoss[1] = mobMiniBoss[1] * 1.6;
                            jatekosStatja[0] = jatekosStatja[0] * 1.10;
                            jatekosStatja[1] = jatekosStatja[1] * 1.10;
                            jatekosPenztarca += 100;
                            jatekosExpLVL++;
                            goto possibleStoryEnd;
                            jatekKimenet = true;
                        }
                        else if (CsataJatekosEleteroStatja <= 0)
                        {
                            Console.WriteLine("-------------------------------------------------------");
                            Console.WriteLine("A játékos elbukta a csatát. A játéknak vége!");
                            Console.WriteLine("-------------------------------------------------------");
                            Console.ReadLine();
                            Console.Clear();

                            jatekKimenet = true;
                        }
                        else
                        {
                            for (int i = 0; i < 1; i++)
                            {
                                int randomNumber = vszam.Next(1, 3);
                                if (randomNumber == 1)
                                {
                                    CsataJatekosSebzesStatjaVégleges2 = (1 + jatekosKardSebzes[1]) * jatekosKardSebzes[0] + jatekosStatja[1];
                                }
                                else
                                {
                                    CsataJatekosSebzesStatjaVégleges2 = jatekosKardSebzes[0] + jatekosStatja[1];
                                }
                            }




                            Console.WriteLine("-------------------------------------------------------");

                            // A játékos támad először
                            Console.WriteLine($"A játékos támad! A troll {Math.Round(CsataJatekosSebzesStatjaVégleges2)} életerőt veszít.");
                            CsataMobFinalBossEletero -= CsataJatekosSebzesStatjaVégleges2;

                            // Ha a goblinok túlélik, akkor támadnak vissza
                            if (CsataMobFinalBossEletero > 0)
                            {
                                Console.WriteLine($"A troll visszatámad! A játékos {Math.Round(CsataMobFinalBossSebzes)} életerőt veszít.");
                                CsataJatekosEleteroStatja -= CsataMobFinalBossSebzes;
                            }

                            Console.WriteLine($"Játékos Életerő: {Math.Round(CsataJatekosEleteroStatja)}");
                            Console.WriteLine($"Troll életereje: {Math.Round(CsataMobFinalBossEletero)}");
                            Console.WriteLine("-------------------------------------------------------");


                            Console.ReadLine(); // Léptetés a következő körre
                        }
                    }

                }


            }
            else //minden wave ami nem MiniBoss vagy FinalBoss
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Goblinokkal harcolsz!");
                Console.WriteLine("Három gonosz goblin rátámad a játékosra!");
                Console.WriteLine("----------------------------------------------------------");

                bool jatekKimenet = false;
                CsataJatekosEleteroStatja = jatekosPancelEletero[0] + jatekosStatja[0];
                CsataJatekosSebzesStatja = jatekosStatja[1] + jatekosKardSebzes[0];
                CsataJatekosKritikusSebzes = 0;
                CsataMobEletero = mobokStatja[0] * 3;
                CsataMobSebzes = mobokStatja[1] * 3;
                double CsataJatekosSebzesStatjaVégleges2 = 0;
                Console.WriteLine(@"
                                                                                                                  /|
                                                                                                                 |\|
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                                 |||
                                                                                                              ~-[{o}]-~
                                                                                                                 |/|
                                                                                                                 |/|
                                                                                         ///~`     |\\_          `0'         =\\\\         . .
                                                                                        ,  |='  ,))\_| ~-_                    _)  \      _/_/|
                                                                                       / ,' ,;((((((    ~ \                  `~~~\-~-_ /~ (_/\ 
                                                                                     /' -~/~)))))))'\_   _/'                      \_  /'  D   |
                                                                                    (       (((((( ~-/ ~-/                          ~-;  /    \--_
                                                                                     ~~--|   ))''    ')  `                            `~~\_    \   )
                                                                                         :        (_  ~\           ,                    /~~-     ./
                                                                                          \        \_   )--__  /(_/)                   |    )    )|
                                                                                ___       |_     \__/~-__    ~~   ,'      /,_;,   __--(   _/      |
                                                                              //~~\`\    /' ~~~----|     ~~~~~~~~'        \-  ((~~    __-~        |
                                                                            ((()   `\`\_(_     _-~~-\                      ``~~ ~~~~~~   \_      /
                                                                             )))     ~----'   /      \                                   )       )
                                                                              (         ;`~--'        :                                _-    ,;;(
                                                                                        |    `\       |                             _-~    ,;;;;)
                                                                                        |    /'`\     ;                          _-~          _/
                                                                                       /~   /    |    )                         /;;;''  ,;;:-~
                                                                                      |    /     / | /                         |;;'   ,''
                                                                                      /   /     |  \\|                         |   ,;(    
                                                                                    _/  /'       \  \_)                   .---__\_    \,--._______
                                                                                   ( )|'         (~-_|                   (;;'  ;;;~~~/' `;;|  `;;;\
                                                                                    ) `\_         |-_;;--__               ~~~----__/'    /'_______/
                                                                                    `----'       (   `~--_ ~~~;;------------~~~~~ ;;;'_/'
                                                                                                 `~~~~~~~~'~~~-----....___;;;____---~~");

                while (!jatekKimenet)  // A játék addig folytatódik, amíg valaki el nem fogy
                {
                    if (CsataMobEletero <= 0)
                    {
                        Console.WriteLine("-------------------------------------------------------");
                        Console.WriteLine("A játékos megnyerte a csatát! Továbbhaladhatsz.");
                        Console.WriteLine("-------------------------------------------------------");
                        Console.ReadLine();
                        waveCounter++;
                        Console.Clear();
                        mobokStatja[0] = mobokStatja[0] * 1.13;
                        mobokStatja[1] = mobokStatja[1] * 1.13;
                        jatekosStatja[0] = jatekosStatja[0] * 1.04;
                        jatekosStatja[1] = jatekosStatja[1] * 1.04;
                        jatekosPenztarca += 15;
                        jatekosExpLVL++;
                        goto mainMenu;
                        jatekKimenet = true;
                    }
                    else if (CsataJatekosEleteroStatja <= 0)
                    {
                        Console.WriteLine("-------------------------------------------------------");
                        Console.WriteLine("A játékos elbukta a csatát. A játéknak vége!");
                        Console.WriteLine("-------------------------------------------------------");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(@"                                                                            _,.-------.,_
                                                                        ,;~'             '~;,
                                                                      ,;                     ;,
                                                                     ;                         ;
                                                                    ,'                         ',
                                                                   ,;                           ;,
                                                                   ; ;      .           .      ; ;
                                                                   | ;   ______       ______   ; |
                                                                   |`/~""     ~"" . ""~     ~""\'|
                                                                   |  ~  ,-~~~^~, | ,~^~~~-,  ~  |
                                                                    |   |        }:{        |   |
                                                                    |   l       / | \       !   |
                                                                    .~  (__,.--"" .^. ""--.,__)  ~.
                                                                    |     ---;' / | \ `;---     |
                                                                     \__.       \/^\/       .__/
                                                                      V| \                 / |V
                                                   __                  | |T~\___!___!___/~T| |                  _____
                                                .-~  ~""-.              | |`IIII_I_I_I_IIII'| |               .-~     ""-.
                                               /         \             |  \,III I I I III,/  |              /           Y
                                              Y          ;              \   `~~~~~~~~~~'    /               i           |
                                              `.   _     `._              \   .       .   /               __)         .'
                                                )=~         `-.._           \.    ^    ./           _..-'~         ~""<_
                                             .-~                 ~`-.._       ^~~~^~~~^       _..-'~                   ~.
                                             /                          ~`-.._           _..-'~                           Y
                                             {        .~""-._                  ~`-.._ .-'~                  _..-~;         ;
                                             `._   _,'     ~`-.._                  ~`-.._           _..-'~     `._    _.- 
                                                ~~""              ~`-.._                  ~`-.._ .-'~              ~~""~
                                              .----.            _..-'  ~`-.._                  ~`-.._          .-~~~~-.
                                             /      `.    _..-'~             ~`-.._                  ~`-.._   (        "".
                                            Y        `=--~                  _..-'  ~`-.._                  ~`-'         |
                                            |                         _..-'~             ~`-.._                         ;
                                            `._                 _..-'~                         ~`-.._            -._ _.'
                                               ""-.='      _..-'~                                     ~`-.._        ~`.
                                                /        `.                                               /            \
                                               /           \                                              |            '
                                               |           ;                                              `.          /
                                               `.       _.'                                                 ""-.____.-'
                                                 ~-----");
                        Console.WriteLine();
                        Console.ReadLine();
                        goto vege;
                        jatekKimenet = true;
                    }
                    else
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            int randomNumber = vszam.Next(1, 3);
                            if (randomNumber == 1)
                            {
                                CsataJatekosSebzesStatjaVégleges2 = (1 + jatekosKardSebzes[1]) * jatekosKardSebzes[0] + jatekosStatja[1];
                            }
                            else
                            {
                                CsataJatekosSebzesStatjaVégleges2 = jatekosKardSebzes[0] + jatekosStatja[1];
                            }
                        }

                        // A játékos visszatámad
                        // CsataMobEletero -= CsataJatekosSebzesStatjaVégleges2;

                        // A goblin megtámadja a játékost
                        // CsataJatekosEleteroStatja -= CsataMobSebzes;


                        Console.WriteLine("-------------------------------------------------------");

                        // A játékos támad először
                        Console.WriteLine($"A játékos támad! A goblinok {Math.Round(CsataJatekosSebzesStatjaVégleges2)} életerőt veszítenek.");
                        CsataMobEletero -= CsataJatekosSebzesStatjaVégleges2;

                        // Ha a goblinok túlélik, akkor támadnak vissza
                        if (CsataMobEletero > 0)
                        {
                            Console.WriteLine($"A goblinok visszatámadnak! A játékos {Math.Round(CsataMobSebzes)} életerőt veszít.");
                            CsataJatekosEleteroStatja -= CsataMobSebzes;
                        }

                        Console.WriteLine($"Játékos Életerő: {Math.Round(CsataJatekosEleteroStatja)}");
                        Console.WriteLine($"Goblinok életereje: {Math.Round(CsataMobEletero)}");
                        Console.WriteLine("-------------------------------------------------------");


                        Console.ReadLine(); // Léptetés a következő körre
                    }
                }

            }


        possibleStoryEnd:
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Sikerült megmentened {kiralynoNev[db00]} a Troll markaitól!");
            Console.WriteLine("De viszont nyomokat találtál a Troll tórnja körül hogy lehetségen még mélyebben mások is segítségre szorulnak.");
            Console.WriteLine($"Mit teszel? Mélyebbre méssz és megmented aki segítségre szorul vagy kimenekülsz {kiralynoNev[db00]}-vel? IGEN | NEM");
            db00++;
            string possibleStoryEnd = Console.ReadLine();
            Console.WriteLine();
            if (possibleStoryEnd.ToLower() == "igen")
            {
                Console.WriteLine($"Rendben, {jatekosNev} Goldberg mélyebbre merészkedik.Sok sikert!");
                Console.ReadLine();
                Console.Clear();
                goto mainMenu;
            }else if(possibleStoryEnd.ToLower() == "nem")
            {
                goto happyEnding;
            }
            else
            {
                Console.Clear();
                goto possibleStoryEnd;
            }




        vege:



            Console.Clear();



            // felirat kozepre Viszlát.... 
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }
            
            Console.WriteLine(@"

                                 .---.                         .---.                        .---.                         .---.           
                            '-.  |   |  .-'               '-.  |   |  .-'              '-.  |   |  .-'               '-.  |   |  .-'     
                              ___|   |___                   ___|   |___                  ___|   |___                   ___|   |___        
                         -=  [     ?     ]  =-         -=  [     ?     ]  =-        -=  [     ?     ]  =-         -=  [  Goldberg ]  =-   
                             `---.   .---'                 `---.   .---'                `---.   .---'                 `---.   .---'       
                          __||__ |   | __||__           __||__ |   | __||__          __||__ |   | __||__           __||__ |   | __||__    
                          '-..-' |   | '-..-'           '-..-' |   | '-..-'          '-..-' |   | '-..-'           '-..-' |   | '-..-'   
                            ||   |   |   ||               ||   |   |   ||              ||   |   |   ||               ||   |   |   ||     
                            ||_.-|   |-,_||               ||_.-|   |-,_||              ||_.-|   |-,_||               ||_.-|   |-,_||     
                          .-'`   `'`'`   `' -.          .-'`   `'`'`   `' -.         .-'`   `'`'`   `' -.          .-'`   `'`'`   `' -.
                        .'    ------------    '.      .'    ------------    '.     .'    ------------    '.      .'    ------------    '.
");
            Console.WriteLine("                                                                         A játéknak vége.");
            Console.ReadKey();
            Environment.Exit(0);

        happyEnding:

            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("Sikeresen ki mentetted a királynőt és vissza tértél a Goldberg királyságba!");
            Console.WriteLine("Itt a vége, fuss el véle!");
            Console.WriteLine();
            Console.WriteLine(@"
                                                                                                              \|
                                                                                                             ,/
                                                                                                            //
                                                                                                          ,//
                                                                                              ___   /|   |//
                                                                                          `__/\_ --(/|___/-/
                                                                                       \|\_-\___ __-_`- /-/ \.
                                                                                      |\_-___,-\_____--/_)' ) \
                                                                                       \ -_ /     __ \( `( __`\|
                                                                                       `\__|      |\)\ ) /(/|
                                                               ,._____.,            ',--//-|      \  |  '   /
                                                              /     __. \,          / /,---|       \       /
                                                             / /    _. \  \        `/`_/ _,'        |     |
                                                            |  | ( (  \   |      ,/\'__/'/          |     |
                                                            |  \  \`--, `_/_------______/           \(   )/
                                                            | | \  \_. \,                            \___/\
                                                            | |  \_   \  \                                 \
                                                            \ \    \_ \   \   /                             \
                                                             \ \  \._  \__ \_|       |                       \
                                                              \ \___  \      \       |                        \
                                                               \__ \__ \  \_ |       \                         |
                                                               |  \_____ \  ____      |                        |
                                                               | \  \__ ---' .__\     |        |               |
                                                               \  \__ ---   /   )     |        \              /
                                                                \   \____/ / ()(      \          `---_       /|
                                                                 \__________/(,--__    \_________.    |    ./ |
                                                                   |     \ \  `---_\--,           \   \_,./   |
                                                                   |      \  \_ ` \    /`---_______-\   \\    /
                                                                    \      \.___,`|   /              \   \\   \
                                                                     \     |  \_ \|   \              (   |:    |
                                                                      \    \      \    |             /  / |    ;
                                                                       \    \      \    \          ( `_'   \  |
                                                                        \.   \      \.   \          `__/   |  |
                                                                          \   \       \.  \                |  |
                                                                           \   \        \  \               (  )
                                                                            \   |        \  |              |  |
                                                                             |  \         \ \              I  `
                                                                             ( __;        ( _;            ('-_';
                                                                             |___\        \___:            \___:
                          
");
            Console.ReadKey();

        }


    }

}