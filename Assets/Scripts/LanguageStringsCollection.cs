using System.Collections.Generic;

public enum LANGUAGE : byte { ENG, RUS, UA, DE }

public class LanguageStringsCollection : Dictionary<LANGUAGE, Dictionary<string, string>>
{
    #region Init 
    public LanguageStringsCollection() : this(BuildLanguageStrings()) { }

    public LanguageStringsCollection(Dictionary<LANGUAGE, Dictionary<string, string>> strings)
    {
        foreach (var item in strings)
            Add(item.Key, item.Value);
    }
    #endregion

    #region Strings 
    public static Dictionary<LANGUAGE, Dictionary<string, string>> BuildLanguageStrings()
    {
        return new Dictionary<LANGUAGE, Dictionary<string, string>>()
        {
            { 
                #region Eng 
                LANGUAGE.ENG, new Dictionary<string, string>()
                { 
                    #region Main Menu 
                    { "Play", "Play" },
                    { "Settings", "Settings" },
                    { "Achievements", "Achievements" },
                    { "About", "Authors" }, 
                    { "Rate", "Rate us." }, 
                    { "Share", "Share on Facebook." }, 
                    #endregion 

                    #region About Menu 
                    {"AboutText", "Game By Akil games" +
                    "\n\n" +
                    "Game design:\n"+ "Yaroslaw Nasarenko\n" +
                    "Pavel Belokurenko \n\n" +
                    "Programming: \n" +
                    "Yaroslaw Nasarenko \n" +
                    "Pavel Belokurenko \n\n" +
                    "Design & Art: \n"+
                    "Masha Nyasha \n\n" +
                    "Sound & Music: \n" +
                    "Internet \n\n" +
                    "Testers: \n"+
                    "Some people from Lucky Kraken\n\n"},
                    #endregion 

                    #region Settings Menu 
                    { "Sound", "Sound:" },
                    { "Music", "Music:" },
                    { "Language", "Language:" },
                    #endregion

                    #region Achievements Menu 
                    {"Achievment1Caption", "Beginner"},
                    {"Achievment1Description", "Pass one level"},
                    {"Achievment2Caption", "Newbie"},
                    {"Achievment2Description", "Pass three levels"},
                    {"Achievment3Caption", "Into the taste"},
                    {"Achievment3Description", "Pass five levels"},
                    {"Achievment4Caption", "Amateur"},
                    {"Achievment4Description", "Pass ten levels"},
                    {"Achievment5Caption", "Titanium"},
                    {"Achievment5Description", "Pass all levels"},
                    {"Achievment6Caption", "Three stars"},
                    {"Achievment6Description", "Collect three stars"},
                    {"Achievment7Caption", "Nine stars"},
                    {"Achievment7Description", "Collect nine stars"},
                    {"Achievment8Caption", "Absolute Star"},
                    {"Achievment8Description", "Collect 25 stars"},
                    {"Achievment9Caption", "Kleptomaniac"},
                    {"Achievment9Description", "Collect all stars"},
                    {"Achievment10Caption", "First blood"},
                    {"Achievment10Description", "Lose at first time"},
                    {"Achievment11Caption", "Combat immersion"},
                    {"Achievment11Description", "Beat first enemy"},
                    {"Achievment12Caption", "The hero next door"},
                    {"Achievment12Description", "Beat vulture"},
                    {"Achievment13Caption", "Observant"},
                    {"Achievment13Description", "Find secret level"},
                    {"Achievment14Caption", "Enemy in Reflection"},
                    {"Achievment14Description", "Meet the Symbiote"},
                    {"Achievment15Caption", "Reload"},
                    {"Achievment15Description", "Lose vulture" },
                    #endregion

                    #region Level Panel 
                    {"ChooseLevelCaption", "Choose level" },
                    {"MoreLevels", "More levels comming soon!" },
                    #endregion 

                    #region Game Panel 

                    #endregion 
                }    
                #endregion 
            },
            { 
                #region Rus 
                LANGUAGE.RUS, new Dictionary<string, string>()
                { 
                    #region Main Menu 
                    { "Play", "Играть" },
                    { "Settings", "Настройки" },
                    { "Achievements", "Достижения" },
                    { "About", "Авторы" },
                    { "Rate", "Проголосовать." },
                    { "Share", "Поделиться на Facebook." }, 
                    #endregion 

                    #region About Menu 
                    {"AboutText", "Игра от Akil games" +
                    "\n\n" +
                    "Игровой дизайн:\n"+ "Ярослав Назаренко\n" +
                    "Павел Белокуренко \n\n" +
                    "Программисты: \n" +
                    "Ярослав Назаренко \n" +
                    "Павел Белокуренко \n\n" +
                    "Дизайн: \n"+
                    "Маша Няша \n\n" +
                    "Звук и музыка: \n" +
                    "Интернет \n\n" +
                    "Тестирование: \n"+
                    "Люди из Кракена\n\n"},
                    #endregion 

                    #region Settings Menu 
                    { "Sound", "Звук:" },
                    { "Music", "Музыка:" },
                    { "Language", "Язык:" },
                    #endregion 

                    #region Achievements Menu 
                    {"Achievment1Caption", "Начинающий"},
                    {"Achievment1Description", "Пройти один уровень"},
                    {"Achievment2Caption", "Новичок"},
                    {"Achievment2Description", "Пройти три уровня"},
                    {"Achievment3Caption", "Вошел во вкус"},
                    {"Achievment3Description", "Пройти пять уровней"},
                    {"Achievment4Caption", "Любитель"},
                    {"Achievment4Description", "Пройти 10 уровней"},
                    {"Achievment5Caption", "Титан"},
                    {"Achievment5Description", "Пройти все уровни"},
                    {"Achievment6Caption", "Три звезды"},
                    {"Achievment6Description", "Собрать три звезды"},
                    {"Achievment7Caption", "Девять звезд"},
                    {"Achievment7Description", "Собрать девять звезд"},
                    {"Achievment8Caption", "Совершеннозвездие"},
                    {"Achievment8Description", "Собрать 25 звезд"},
                    {"Achievment9Caption", "Клептоман"},
                    {"Achievment9Description", "Собрать все звезды"},
                    {"Achievment10Caption", "Первая кровь"},
                    {"Achievment10Description", "Проиграть в первый раз"},
                    {"Achievment11Caption", "Боевое крещение"},
                    {"Achievment11Description", "Победить первого врага"},
                    {"Achievment12Caption", "Герой по соседству"},
                    {"Achievment12Description", "Победить стервятника"},
                    {"Achievment13Caption", "Наблюдательный"},
                    {"Achievment13Description", "Найти секретный уровень"},
                    {"Achievment14Caption", "Враг в отражении"},
                    {"Achievment14Description", "Встретить симбиота"},
                    {"Achievment15Caption", "Все сначала"},
                    {"Achievment15Description", "Проиграть стервятнику" },
                    #endregion 

                    #region Level Panel 
                    {"ChooseLevelCaption", "Выберите уровень" },
                    {"MoreLevels", "Продолжение скоро будет!" },
                    #endregion 

                    #region Game Panel 

                    #endregion 
                }    
                #endregion 
            },
            { 
                #region UA 
                LANGUAGE.UA, new Dictionary<string, string>()
                { 
                    #region Main Menu 
                    { "Play", "Грати" },
                    { "Settings", "Настройки" },
                    { "Achievements", "Досягнення" },
                    { "About", "Автори" },
                    { "Rate", "Проголосувати." },
                    { "Share", "Подiлитися на Facebook." }, 
                    #endregion 

                    #region About Menu 
                    {"AboutText", "Гра вiд Akil games" +
                    "\n\n" +
                    "Ігровий дизайн:\n"+ "Ярослав Назаренко\n" +
                    "Павел Белокуренко \n\n" +
                    "Програмування: \n" +
                    "Ярослав Назаренко \n" +
                    "Павел Белокуренко \n\n" +
                    "Дизайн: \n"+
                    "Маша Няша \n\n" +
                    "Звук и музика: \n" +
                    "Интернет \n\n" +
                    "Тестування: \n"+
                    "Люди з Кракена\n\n"},
                    #endregion 

                    #region Settings Menu 
                    { "Sound", "Звук:" },
                    { "Music", "Музика:" },
                    { "Language", "Мова:" },
                    #endregion 

                    #region Achievements Menu 
                    {"Achievment1Caption", "Початківець"},
                    {"Achievment1Description", "Пройти один рівень"},
                    {"Achievment2Caption", "Новачок"},
                    {"Achievment2Description", "Пройти три рівня"},
                    {"Achievment3Caption", "Увійшов у вкус"},
                    {"Achievment3Description", "Пройти пять рівнiв"},
                    {"Achievment4Caption", "Любитель"},
                    {"Achievment4Description", "Пройти 10 рівнiв"},
                    {"Achievment5Caption", "Титан"},
                    {"Achievment5Description", "Пройти все рівні"},
                    {"Achievment6Caption", "Три звезды"},
                    {"Achievment6Description", "Зібрати три зірки"},
                    {"Achievment7Caption", "Дев'ять звезд"},
                    {"Achievment7Description", "Зібрати дев'ять зірок"},
                    {"Achievment8Caption", "Повнозвездіе"},
                    {"Achievment8Description", "Зібрати 25 зірок"},
                    {"Achievment9Caption", "Клептоман"},
                    {"Achievment9Description", "Зібрати все зіроки"},
                    {"Achievment10Caption", "Перша кров"},
                    {"Achievment10Description", "Програти в перший раз"},
                    {"Achievment11Caption", "Бойове хрещення"},
                    {"Achievment11Description", "Перемогти першого ворога"},
                    {"Achievment12Caption", "Герой по сусідству"},
                    {"Achievment12Description", "Перемогти стерв'ятника"},
                    {"Achievment13Caption", "Наглядова"},
                    {"Achievment13Description", "Найти секретный рiвень"},
                    {"Achievment14Caption", "Ворог у тіні"},
                    {"Achievment14Description", "Зустріти симбиота"},
                    {"Achievment15Caption", "Все з початку"},
                    {"Achievment15Description", "Програти стерв'ятникові" },
                    #endregion 

                    #region Level Panel 
                    {"ChooseLevelCaption", "Виберіть рівень" },
                    {"MoreLevels", "Продовження скоро буде!" },
                    #endregion 

                    #region Game Panel 

                    #endregion 
                }    
                #endregion 
            },
            { 
                #region DE 
                LANGUAGE.DE, new Dictionary<string, string>()
                { 
                    #region Main Menu 
                    { "Play", "Spielen" },
                    { "Settings", "Einstellungen" },
                    { "Achievements", "Erfolge" },
                    { "About", "Autoren" },
                    { "Rate", "Abstimmen." },
                    { "Share", "Teilen auf Facebook." }, 
                    #endregion 

                    #region About Menu 
                    {"AboutText", "Spiel auf Akil games" +
                    "\n\n" +
                    "Spieldesign:\n"+ "Ярослав Назаренко\n" +
                    "Павел Белокуренко \n\n" +
                    "Programmierung: \n" +
                    "Ярослав Назаренко \n" +
                    "Павел Белокуренко \n\n" +
                    "Design: \n"+
                    "Маша Няша \n\n" +
                    "Ton und Musik: \n" +
                    "Интернет \n\n" +
                    "Testen: \n"+
                    "Люди з Кракена\n\n"},
                    #endregion 

                    #region Settings Menu 
                    { "Sound", "Ton:" },
                    { "Music", "Musik:" },
                    { "Language", "Sprache:" },
                    #endregion 

                    #region Achievements Menu 
                    {"Achievment1Caption", "Anfänger"},
                    {"Achievment1Description", "Gehen durch eine Ebene"},
                    {"Achievment2Caption", "Neuling"},
                    {"Achievment2Description", "Gehen durch drei Ebene"},
                    {"Achievment3Caption", "Ich bekam einen Geschmack"},
                    {"Achievment3Description", "Gehen durch fünf Ebene"},
                    {"Achievment4Caption", "Amateur"},
                    {"Achievment4Description", "Gehen durch zehn Ebene"},
                    {"Achievment5Caption", "Titan"},
                    {"Achievment5Description", "Gehen durch alle Ebene"},
                    {"Achievment6Caption", "Drei Sterne"},
                    {"Achievment6Description", "Sammeln drei Sterne"},
                    {"Achievment7Caption", "Neun Sterne"},
                    {"Achievment7Description", "Sammeln neun Sterne"},
                    {"Achievment8Caption", "Berühmtheit"},
                    {"Achievment8Description", "Sammeln  25 Sterne"},
                    {"Achievment9Caption", "Kleptomane"},
                    {"Achievment9Description", "Sammeln  alle Sterne"},
                    {"Achievment10Caption", "Erstes Blut"},
                    {"Achievment10Description", "Verlieren zum ersten Mal"},
                    {"Achievment11Caption", "Feuertaufe"},
                    {"Achievment11Description", "Gewinnen ersten Feind"},
                    {"Achievment12Caption", "Nachbarschaft Held"},
                    {"Achievment12Description", "Gewinnen Geier"},
                    {"Achievment13Caption", "Aufsichts"},
                    {"Achievment13Description", "Geheimnis Ebene zu finden"},
                    {"Achievment14Caption", "Der Feind der Reflexion"},
                    {"Achievment14Description", "Treffen Symbionten"},
                    {"Achievment15Caption", "Anfangs"},
                    {"Achievment15Description", "verlieren Geier" },
                    #endregion 

                    #region Level Panel 
                    {"ChooseLevelCaption", "Wählen Sie Ebene" },
                    {"MoreLevels", "Mehr Level Kommen bald" },
                    #endregion 

                    #region Game Panel 

                    #endregion 
                }    
                #endregion 
            }
        };
    }
    #endregion
}