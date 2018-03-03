using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultViewer
{

    public partial class main : Form
    {
        public string[] juryList;        //Массив с ФИО жюри
        public string[] contestList;     //Массив с ФИО конкурсантов


        /* Двумерный целочисленный массив, содержащий в виде таблицы выбор жюри
         * Первое измерение содержит индекс элемента из juryList, содержащий ФИО жюри
         * Второе измерение содержит 10 элементов, кождый из которых содержит индекс элемента из contestList, содержащий ФИО конкурсанта
         * Максимальное количество элементов в первом измерении: 15 (жюри, принимавшие участие в голосовании)
         * Максимальное количество элементов во втором измерении: 10 (выбранные конкурсанты)
         */
        public int[][] juryChoise;

        public string[] tempJuryList;
        public string[] tempContestList;
        public int[][] tempJuryChoise;


        public Color ContBarColor = Color.FromArgb(255, 26, 43, 63);
        public Color sndContBarColor = Color.FromArgb(255, 203, 12, 179);
        public int ContBarFontSize = 20;
        public int ContBarWidth = 405;
        public int ContBarHeight = 35;

        public int XNum = 2;
        public int YNum = 20;
        public int FrameRate = 20;
        public int FrameInterval = 50;
        public string QuitFrase = "Показ завершён";

        public Color PointBarColor = Color.FromArgb(255, 91, 218, 211);
        public Color sndPointBarColor = Color.FromArgb(255, 203, 12, 179);
        public int pointBarWidth = 43;
        public int pointBarHeight = 27;
        public int pointBarInterval = 10;
        public int pointBarFontSize = 20;

        public Color JuryBarColor = Color.FromArgb(255, 26, 43, 63);
        public Color sndJuryBarColor = Color.FromArgb(255, 203, 12, 179);
        public int JuryBarWidth = 405;
        public int JuryBarHeight = 35;
        public int JuryBarFontSize = 20;



        public void StatusUpdate(string text)
        {
            StatusLabel.Text = text;
            StatusLabel.Refresh();
        }

        public main()
        {
            InitializeComponent();
            juryChoise = null;
            juryList = null;
            contestList = null;
        }



        /// <summary>
        /// Вызов функции GetJuryAndCompitList необходим для ввода ФИО жюри и конкурсантов.
        /// Для этого создаётся экземпляр диалогового окна, в котором пользователь вводит данные.
        /// Если пользователь ввёл данные и нажал на кнопку ОК, массивы juryList и contestList заполняются и функция возвращает истину.
        /// Если пользователь нажал кнопку отмены, функция позвращает ложь, таким образом прерывая процесс.
        /// </summary>
        /// <param name="newData">Режим изменения данных или введения новых</param>
        /// <returns>Результат введения пользователем данных. В случае успеха true, иначе false</returns>
        public bool GetJuryAndCompitList(bool newData)
        {
            ContestDataDialog cdd;

            if (newData)
            {
                cdd = new ContestDataDialog();
            }
            else
            {
                string[] adaptedContestList = new string[contestList.Length - 1]; // zero element is empty field. have to delete it
                Array.Copy(contestList, 1, adaptedContestList, 0, adaptedContestList.Length);
                cdd = new ContestDataDialog(juryList, adaptedContestList);
            }

            cdd.ShowDialog();
            if (cdd.DialogResult != DialogResult.OK)
            {
                cdd.Dispose();
                return false;
            }
            else
            {
                if (newData)
                {
                    juryList = new string[cdd.GetJuryCount()];
                    contestList = new string[cdd.GetContestCount() + 1];
                    cdd.GetJuryList(ref juryList);
                    cdd.GetContestList(ref contestList);
                    cdd.Dispose();
                    return true;
                }
                else
                {
                    tempJuryList = new string[cdd.GetJuryCount()];
                    tempContestList = new string[cdd.GetContestCount() + 1];
                    cdd.GetJuryList(ref tempJuryList);
                    cdd.GetContestList(ref tempContestList);
                    cdd.Dispose();
                    return true;
                }
            }
        }

        /// <summary>
        /// Checks string existance in entered array and returns it's id. If searching fails, returns -1
        /// </summary>
        /// <param name="expectedJury">String, expected to find</param>
        /// <returns></returns>
        private int CheckExistance(string[] stringArray, string expectedMember)
        {
            for (int i = 0; i < stringArray.Length; i++)
                if (stringArray[i] == expectedMember)
                    return i;
            return -1;
        }

        private void TranslateJuryChoise(ref int[][] oldJuryChoise, 
                                         ref int[][] newJuryChoise, 
                                         ref string[] oldContestList, 
                                         ref string[] newContestList, 
                                         ref string[] oldJuryList,
                                         ref string[] newJuryList)
        {
            // Init new JuryChoise
            tempJuryChoise = new int[newJuryList.Length][];
            for (int i = 0; i < newJuryList.Length; i++)
                tempJuryChoise[i] = new int[10];


            int survivedJuryId;
            int survivedContestId;

            for (int juryId = 0; juryId < oldJuryList.Length; juryId++)
            {
                //Check, if this jury is still in new list
                if ((survivedJuryId = CheckExistance(newJuryList, oldJuryList[juryId])) != -1)
                {
                    for (int numOfPoint = 0; numOfPoint < 10; numOfPoint++)
                    {
                        //Check, if current contest is still in new list
                        if ((survivedContestId = CheckExistance(tempContestList, contestList[oldJuryChoise[survivedJuryId][numOfPoint]])) != -1)
                        {
                            newJuryChoise[juryId][numOfPoint] = survivedContestId;
                        }
                    }
                }
            }
        }

        public void AddEmptyField(ref string[] list)
        {
            list[0] = "...";
        }

        private void modifyWithNewData(bool newData)
        {
            if (newData)
            {
                if (!GetJuryAndCompitList(newData))
                {
                    StatusUpdate("Отменено");
                }
                else
                {
                    Array.Sort(juryList);
                    Array.Sort(contestList);
                    AddEmptyField(ref contestList);
                    JuryChoiseDialog jcd = new JuryChoiseDialog(juryList, contestList);
                    jcd.ShowDialog();

                    if (jcd.DialogResult == DialogResult.OK)
                    {
                        juryChoise = new int[juryList.Length][];
                        jcd.GetJuryChoise(ref juryChoise);
                        replaceData.Visible = true;
                        ReplaceVisualElements();
                        InitPointListbox();
                        SetDataButton.Text = "Изменить данные";
                        StatusUpdate("Запись новых данных завершена");
                    }
                    else
                    {
                        StatusUpdate("Отменено");
                    }
                }
            }
            else
            {
                if (!GetJuryAndCompitList(newData = false))
                {
                    StatusUpdate("Отменено");
                }
                else
                {
                    Array.Sort(tempJuryList);
                    Array.Sort(tempContestList);
                    TranslateJuryChoise(ref juryChoise, 
                                        ref tempJuryChoise,
                                        ref contestList,
                                        ref tempContestList,
                                        ref juryList,
                                        ref tempJuryList);
                    AddEmptyField(ref tempContestList);
                    JuryChoiseDialog jcd = new JuryChoiseDialog(tempJuryList, tempContestList, tempJuryChoise);
                    jcd.ShowDialog();
                    
                    if (jcd.DialogResult == DialogResult.OK)
                    {
                        jcd.GetJuryChoise(ref juryChoise);
                        contestList = new string[tempContestList.Length];
                        Array.Copy(tempContestList, contestList, tempContestList.Length);
                        juryList = new string[tempJuryList.Length];
                        Array.Copy(tempJuryList, juryList, tempJuryList.Length);
                        InitPointListbox();
                        StatusUpdate("Запись новых данных завершена");
                    }
                    else
                    {
                        StatusUpdate("Отменено");
                    }
                }
            }
        }



        private void replaceData_Click(object sender, EventArgs e)
        {
            modifyWithNewData(true);
        }



        private void SetDataButton_Click(object sender, EventArgs e)
        {
            if ((juryList == null) && (contestList == null))
            {
                modifyWithNewData(true);
            }
            else
            {
                modifyWithNewData(false);
            }
        }
        


        private string ReadAndCheckIfNotNull(StreamReader file)
        {
            string str = file.ReadLine();
            if (str == null)
            {
                throw new FormatException();
            }
            else
            {
                return str;
            }
        }



        private void ReadFile(StreamReader file)
        {
            try
            {
                int length = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                juryList = new string[length];

                #region Reading File

                for (int i = 0; i < length; i++)
                {
                    juryList[i] = file.ReadLine();
                }

                length = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                contestList = new string[length];

                for (int i = 0; i < length; i++)
                {
                    contestList[i] = ReadAndCheckIfNotNull(file);
                }

                juryChoise = new int[juryList.Length][];
                for (int i = 0; i < juryList.Length; i++)
                {
                    juryChoise[i] = new int[12];
                }

                for (int i = 0; i < juryList.Length; i++)
                {
                    for (int ii = 0; ii < 10; ii++)
                    {
                        juryChoise[i][ii] = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                    }
                }
                
                ContBarColor = Color.FromArgb(255, Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                   Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                   Convert.ToInt32(ReadAndCheckIfNotNull(file)));

                sndContBarColor = Color.FromArgb(255, Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                      Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                      Convert.ToInt32(ReadAndCheckIfNotNull(file)));


                ContBarFontSize = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                ContBarWidth = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                ContBarHeight = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                XNum = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                YNum = Convert.ToInt32(ReadAndCheckIfNotNull(file));

                PointBarColor = Color.FromArgb(255, Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                    Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                    Convert.ToInt32(ReadAndCheckIfNotNull(file)));

                sndPointBarColor = Color.FromArgb(255, Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                       Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                       Convert.ToInt32(ReadAndCheckIfNotNull(file)));

                pointBarWidth = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                pointBarHeight = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                pointBarInterval = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                pointBarFontSize = Convert.ToInt32(ReadAndCheckIfNotNull(file));

                JuryBarColor = Color.FromArgb(255, Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                   Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                   Convert.ToInt32(ReadAndCheckIfNotNull(file)));

                sndJuryBarColor = Color.FromArgb(255, Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                      Convert.ToInt32(ReadAndCheckIfNotNull(file)),
                                                      Convert.ToInt32(ReadAndCheckIfNotNull(file)));

                JuryBarWidth = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                JuryBarHeight = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                JuryBarFontSize = Convert.ToInt32(ReadAndCheckIfNotNull(file));

                QuitFrase = ReadAndCheckIfNotNull(file);
                FrameRate = Convert.ToInt32(ReadAndCheckIfNotNull(file));
                FrameInterval = Convert.ToInt32(ReadAndCheckIfNotNull(file));

                #endregion

                StatusUpdate("Загрузка завершена");
                replaceData.Visible = true;
                SetDataButton.Text = "Изменить данные";
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Во время чтения файла возникла непредвиденная ошибка. Возможно, файл повреждён", "Ошибка во время чтения файла", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                juryList = null;
                contestList = null;
                juryChoise = null;
                StatusUpdate("Ошибка во время чтения файла");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, 
                                "Непредвиденная ошибка", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                juryList = null;
                contestList = null;
                juryChoise = null;
                StatusUpdate("Непредвиденная ошибка");
            }



        }



        private void SaveButton_Click(object sender, EventArgs e)
        {
            if ((juryChoise != null) && (juryList != null) && (contestList != null))
            {
                try
                {
                    //string currentDirectory = @Directory.GetCurrentDirectory() + "\\Data.txt";
                    //saveFile = new StreamWriter(currentDirectory, false, Encoding.UTF8);
                    string currentDirectory = @Directory.GetCurrentDirectory() + "\\Data.txt";

                    FileInfo f = new FileInfo(currentDirectory);
                    using (FileStream fs = f.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        using (StreamWriter saveFile = new StreamWriter(fs, Encoding.UTF8))
                        {
                            #region Writing file

                            saveFile.WriteLine(juryList.Length);
                            for (int i = 0; i < juryList.Length; i++)
                            {
                                saveFile.WriteLine(juryList[i]);
                            }
                            saveFile.WriteLine(contestList.Length);
                            for (int i = 0; i < contestList.Length; i++)
                            {
                                saveFile.WriteLine(contestList[i]);
                            }
                            for (int i = 0; i < juryList.Length; i++)
                            {
                                for (int ii = 0; ii < 10; ii++)
                                {
                                    saveFile.WriteLine(juryChoise[i][ii]);
                                }
                            }

                            saveFile.WriteLine(ContBarColor.R);
                            saveFile.WriteLine(ContBarColor.G);
                            saveFile.WriteLine(ContBarColor.B);
                            saveFile.WriteLine(sndContBarColor.R);
                            saveFile.WriteLine(sndContBarColor.G);
                            saveFile.WriteLine(sndContBarColor.B);
                            saveFile.WriteLine(ContBarFontSize);
                            saveFile.WriteLine(ContBarWidth);
                            saveFile.WriteLine(ContBarHeight);

                            saveFile.WriteLine(XNum);
                            saveFile.WriteLine(YNum);

                            saveFile.WriteLine(PointBarColor.R);
                            saveFile.WriteLine(PointBarColor.G);
                            saveFile.WriteLine(PointBarColor.B);
                            saveFile.WriteLine(sndPointBarColor.R);
                            saveFile.WriteLine(sndPointBarColor.G);
                            saveFile.WriteLine(sndPointBarColor.B);
                            saveFile.WriteLine(pointBarWidth);
                            saveFile.WriteLine(pointBarHeight);
                            saveFile.WriteLine(pointBarInterval);
                            saveFile.WriteLine(pointBarFontSize);

                            saveFile.WriteLine(JuryBarColor.R);
                            saveFile.WriteLine(JuryBarColor.G);
                            saveFile.WriteLine(JuryBarColor.B);
                            saveFile.WriteLine(sndJuryBarColor.R);
                            saveFile.WriteLine(sndJuryBarColor.G);
                            saveFile.WriteLine(sndJuryBarColor.B);
                            saveFile.WriteLine(JuryBarWidth);
                            saveFile.WriteLine(JuryBarHeight);
                            saveFile.WriteLine(JuryBarFontSize);

                            saveFile.WriteLine(QuitFrase);
                            saveFile.WriteLine(FrameRate);
                            saveFile.WriteLine(FrameInterval);

                            #endregion
                        }
                    }
                    StatusUpdate("Сохранение завершено");
                    f = null;
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Неожиданная ошибка: \n{ex.Message}", 
                                    "Ошибка", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                    StatusUpdate("Ошибка во время сохранения");
                }
            }
            else
            {
                MessageBox.Show("Отсуствуют данные для сохранения", 
                                "Ошибка", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
            }
        }        



        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            string currentDirectory;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.Filter = "Text Files|*.txt";

            StreamReader file = null;

            try
            {
                currentDirectory = @Directory.GetCurrentDirectory() + "\\Data.txt";
                file = new StreamReader(currentDirectory, Encoding.UTF8, false);
            }
            catch (FileNotFoundException exc)
            {
                DialogResult result = MessageBox.Show("Файл с сохранёнными данными не найден в директории с программой. Хотите вручную выбрать файл?",
                                                      "Файл не найден", 
                                                      MessageBoxButtons.YesNo, 
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        file = new StreamReader(ofd.FileName, Encoding.UTF8);
                    }
                    else
                    {
                        StatusUpdate("Отменено");
                        file = null;
                    }
                }
                else
                {
                    StatusUpdate("Отменено");
                }
            }
            finally
            {
                if (file != null)
                {
                    if (juryChoise != null)
                    {
                        DialogResult result = MessageBox.Show("Обнаружены введенные данные. Если они не сохранены, то будут утеряны. \nПродолжить?", 
                                                              "Внимание", 
                                                              MessageBoxButtons.YesNo, 
                                                              MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            ReadFile(file);
                            ReplaceVisualElements();
                            InitPointListbox();
                            currentDirectory = null;
                            ofd.Dispose();
                            file.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Загрузка отменена", "Отменено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ofd.Dispose();
                            file.Dispose();
                        }
                    }
                    else
                    {
                        ReadFile(file);
                        ReplaceVisualElements();
                        InitPointListbox();
                        currentDirectory = null;
                        ofd.Dispose();
                        file.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Загрузка отменена", "Отменено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        private void ShowDataButton_Click(object sender, EventArgs e)
        {
            //string msg = null;

            //if ((juryChoise != null) && (contestList != null) && (juryList != null))
            //{
            //	for (int i = 0; i < juryList.Length; i++)
            //	{
            //		msg += $"Жюри: {juryList[i]}\n\n\n";

            //		for (int ii = 0; ii < 10; ii++)
            //		{
            //			msg += $"{ii + 1}: {contestList[juryChoise[i][ii]]}\n";
            //		}
            //		MessageBox.Show(msg, "Вывод");
            //		msg = null;
            //	}

            //}
            //else
            //{
            //	MessageBox.Show("Отсутствуют данные", "Ошбика");
            //}

            if ((juryChoise != null) && (juryList != null) && (contestList != null))
            {


                MainViewer mv = new MainViewer(this);
                StatusUpdate("Просмотр запущен");
                mv.ShowDialog();

                if (mv.DialogResult == DialogResult.OK)
                {
                    StatusUpdate("Просмотр завершён");
                }
                mv.Dispose();
            }
            else
            {
                MessageBox.Show("Отсутствуют данные для вывода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void InitPointListbox()
        {
            PreviewDataListBox.Items.Clear();

            Dictionary<string, int> contPoints = new Dictionary<string, int>();
            foreach (string cont in contestList)
            {
                contPoints.Add(cont, 0);
            }
            int earnedPoints = 0;
            for (int i = 0; i < juryList.Length; i++)
            {
                for (int ii = 0; ii < 10; ii++)
                {
                    if (ii < 9)
                        earnedPoints = ii + 1;
                    if (ii == 9)
                        earnedPoints = 10;
                    if (ii == 10)
                        earnedPoints = 12;

                    contPoints[contestList[juryChoise[i][ii]]] += earnedPoints;
                }
            }

            contPoints.Remove("...");
            contPoints = contPoints.OrderBy(pair => pair.Value)
                                   .Reverse()
                                   .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (KeyValuePair<string, int> contest in contPoints)
            {
                PreviewDataListBox.Items.Add($"{contest.Value}    {contest.Key}");
            }
            PreviewDataListBox.Refresh();
            PreviewDataListBox.Visible = true;
        }

        

        private void ReplaceVisualElements()
        {
            SetDataButton.Location = new Point(15, 100);
            replaceData.Location = new Point(181, 100);
            ShowDataButton.Location = new Point(15, 136);
            LoadDataButton.Location = new Point(15, 172);
            SaveButton.Location = new Point(100, 172);

        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.Filter = "Text Files|*.txt";

            StreamReader file = null;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    file = new StreamReader(ofd.FileName, Encoding.UTF8);
                    ReadFile(file);
                    ReplaceVisualElements();
                    InitPointListbox();
                    ofd.Dispose();
                    file.Dispose();
                }
                catch (Exception ee)
                {
                    MessageBox.Show($"Во время четния/открытия файла возникла ошибка\nПодробности: \n\n{ee.Message}\n{ee.InnerException}",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                StatusUpdate("Отменено");
                file = null;
            }
        }

        private void MainViewerSettingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MVSettings mvs = new MVSettings(this);
            mvs.ShowDialog();
            if (mvs.DialogResult == DialogResult.OK)
            {
                StatusUpdate("Настройки показа обновлены");
            }
            else
            {
                StatusUpdate("Натройка отменена");
            }
        }

        private void CreatorsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Creators cr = new Creators();
            cr.Show();
        }
    }

}

