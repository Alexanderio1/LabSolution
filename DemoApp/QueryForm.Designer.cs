namespace DemoApp
{
    partial class QueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabContracts = new System.Windows.Forms.TabPage();
            this.chkAllPeriod = new System.Windows.Forms.CheckBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnContracts = new System.Windows.Forms.Button();
            this.lvContracts = new System.Windows.Forms.ListView();
            this.colFirm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPublishers = new System.Windows.Forms.TabPage();
            this.btnPublishers = new System.Windows.Forms.Button();
            this.lvPublishers = new System.Windows.Forms.ListView();
            this.colPubName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPubCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabAuthors = new System.Windows.Forms.TabPage();
            this.btnAuthors = new System.Windows.Forms.Button();
            this.lvAuthors = new System.Windows.Forms.ListView();
            this.colAuthorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAuthorCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.btnBooks = new System.Windows.Forms.Button();
            this.lvBooks = new System.Windows.Forms.ListView();
            this.colBookName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBookCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabRequests = new System.Windows.Forms.TabPage();
            this.btnRequests = new System.Windows.Forms.Button();
            this.cmbBuyer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lvRequests = new System.Windows.Forms.ListView();
            this.colReqBuyer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReqDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReqBook = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReqAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReqStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabRating = new System.Windows.Forms.TabPage();
            this.btnRating = new System.Windows.Forms.Button();
            this.lvRating = new System.Windows.Forms.ListView();
            this.colRatingType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRatingName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRatingScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabDelayed = new System.Windows.Forms.TabPage();
            this.btnDelayed = new System.Windows.Forms.Button();
            this.cmbDelayedSupplier = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lvDelayed = new System.Windows.Forms.ListView();
            this.colDelaySupplier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDelayBook = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDelayDue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDelayDays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabCompleted = new System.Windows.Forms.TabPage();
            this.btnCompleted = new System.Windows.Forms.Button();
            this.cmbCompletedBuyer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lvCompleted = new System.Windows.Forms.ListView();
            this.colCompBuyer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompBook = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabContracts.SuspendLayout();
            this.tabPublishers.SuspendLayout();
            this.tabAuthors.SuspendLayout();
            this.tabBooks.SuspendLayout();
            this.tabRequests.SuspendLayout();
            this.tabRating.SuspendLayout();
            this.tabDelayed.SuspendLayout();
            this.tabCompleted.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabContracts);
            this.tabControl1.Controls.Add(this.tabPublishers);
            this.tabControl1.Controls.Add(this.tabAuthors);
            this.tabControl1.Controls.Add(this.tabBooks);
            this.tabControl1.Controls.Add(this.tabRequests);
            this.tabControl1.Controls.Add(this.tabRating);
            this.tabControl1.Controls.Add(this.tabDelayed);
            this.tabControl1.Controls.Add(this.tabCompleted);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 611);
            this.tabControl1.TabIndex = 0;
            // 
            // tabContracts
            // 
            this.tabContracts.Controls.Add(this.chkAllPeriod);
            this.tabContracts.Controls.Add(this.dtTo);
            this.tabContracts.Controls.Add(this.dtFrom);
            this.tabContracts.Controls.Add(this.label2);
            this.tabContracts.Controls.Add(this.label1);
            this.tabContracts.Controls.Add(this.btnContracts);
            this.tabContracts.Controls.Add(this.lvContracts);
            this.tabContracts.Location = new System.Drawing.Point(4, 34);
            this.tabContracts.Name = "tabContracts";
            this.tabContracts.Padding = new System.Windows.Forms.Padding(6);
            this.tabContracts.Size = new System.Drawing.Size(976, 573);
            this.tabContracts.TabIndex = 0;
            this.tabContracts.Text = "Договоры";
            this.tabContracts.UseVisualStyleBackColor = true;
            // 
            // chkAllPeriod
            // 
            this.chkAllPeriod.AutoSize = true;
            this.chkAllPeriod.Checked = true;
            this.chkAllPeriod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllPeriod.Location = new System.Drawing.Point(10, 12);
            this.chkAllPeriod.Name = "chkAllPeriod";
            this.chkAllPeriod.Size = new System.Drawing.Size(174, 29);
            this.chkAllPeriod.TabIndex = 6;
            this.chkAllPeriod.Text = "За весь период";
            this.chkAllPeriod.UseVisualStyleBackColor = true;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(509, 10);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(242, 31);
            this.dtTo.TabIndex = 5;
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(213, 10);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(242, 31);
            this.dtFrom.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "по";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "c";
            // 
            // btnContracts
            // 
            this.btnContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContracts.Location = new System.Drawing.Point(839, 6);
            this.btnContracts.Name = "btnContracts";
            this.btnContracts.Size = new System.Drawing.Size(125, 40);
            this.btnContracts.TabIndex = 1;
            this.btnContracts.Text = "Показать";
            this.btnContracts.UseVisualStyleBackColor = true;
            this.btnContracts.Click += new System.EventHandler(this.btnContracts_Click);
            // 
            // lvContracts
            // 
            this.lvContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                        | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvContracts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFirm,
            this.colCount,
            this.colRange});
            this.lvContracts.FullRowSelect = true;
            this.lvContracts.HideSelection = false;
            this.lvContracts.Location = new System.Drawing.Point(10, 60);
            this.lvContracts.Name = "lvContracts";
            this.lvContracts.Size = new System.Drawing.Size(954, 504);
            this.lvContracts.TabIndex = 0;
            this.lvContracts.UseCompatibleStateImageBehavior = false;
            this.lvContracts.View = System.Windows.Forms.View.Details;
            // 
            // colFirm
            // 
            this.colFirm.Text = "Фирма";
            this.colFirm.Width = 320;
            // 
            // colCount
            // 
            this.colCount.Text = "Договоров";
            this.colCount.Width = 120;
            // 
            // colRange
            // 
            this.colRange.Text = "Период";
            this.colRange.Width = 250;
            // 
            // tabPublishers
            // 
            this.tabPublishers.Controls.Add(this.btnPublishers);
            this.tabPublishers.Controls.Add(this.lvPublishers);
            this.tabPublishers.Location = new System.Drawing.Point(4, 34);
            this.tabPublishers.Name = "tabPublishers";
            this.tabPublishers.Padding = new System.Windows.Forms.Padding(6);
            this.tabPublishers.Size = new System.Drawing.Size(976, 573);
            this.tabPublishers.TabIndex = 1;
            this.tabPublishers.Text = "Издательства";
            this.tabPublishers.UseVisualStyleBackColor = true;
            // 
            // btnPublishers
            // 
            this.btnPublishers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPublishers.Location = new System.Drawing.Point(839, 6);
            this.btnPublishers.Name = "btnPublishers";
            this.btnPublishers.Size = new System.Drawing.Size(125, 40);
            this.btnPublishers.TabIndex = 2;
            this.btnPublishers.Text = "Обновить";
            this.btnPublishers.UseVisualStyleBackColor = true;
            this.btnPublishers.Click += new System.EventHandler(this.btnPublishers_Click);
            // 
            // lvPublishers
            // 
            this.lvPublishers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                        | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPublishers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPubName,
            this.colPubCount});
            this.lvPublishers.FullRowSelect = true;
            this.lvPublishers.HideSelection = false;
            this.lvPublishers.Location = new System.Drawing.Point(10, 60);
            this.lvPublishers.Name = "lvPublishers";
            this.lvPublishers.Size = new System.Drawing.Size(954, 504);
            this.lvPublishers.TabIndex = 1;
            this.lvPublishers.UseCompatibleStateImageBehavior = false;
            this.lvPublishers.View = System.Windows.Forms.View.Details;
            // 
            // colPubName
            // 
            this.colPubName.Text = "Издательство";
            this.colPubName.Width = 400;
            // 
            // colPubCount
            // 
            this.colPubCount.Text = "Заказов";
            this.colPubCount.Width = 180;
            // 
            // tabAuthors
            // 
            this.tabAuthors.Controls.Add(this.btnAuthors);
            this.tabAuthors.Controls.Add(this.lvAuthors);
            this.tabAuthors.Location = new System.Drawing.Point(4, 34);
            this.tabAuthors.Name = "tabAuthors";
            this.tabAuthors.Padding = new System.Windows.Forms.Padding(6);
            this.tabAuthors.Size = new System.Drawing.Size(976, 573);
            this.tabAuthors.TabIndex = 2;
            this.tabAuthors.Text = "Авторы";
            this.tabAuthors.UseVisualStyleBackColor = true;
            // 
            // btnAuthors
            // 
            this.btnAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuthors.Location = new System.Drawing.Point(839, 6);
            this.btnAuthors.Name = "btnAuthors";
            this.btnAuthors.Size = new System.Drawing.Size(125, 40);
            this.btnAuthors.TabIndex = 3;
            this.btnAuthors.Text = "Обновить";
            this.btnAuthors.UseVisualStyleBackColor = true;
            this.btnAuthors.Click += new System.EventHandler(this.btnAuthors_Click);
            // 
            // lvAuthors
            // 
            this.lvAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                        | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAuthors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAuthorName,
            this.colAuthorCount});
            this.lvAuthors.FullRowSelect = true;
            this.lvAuthors.HideSelection = false;
            this.lvAuthors.Location = new System.Drawing.Point(10, 60);
            this.lvAuthors.Name = "lvAuthors";
            this.lvAuthors.Size = new System.Drawing.Size(954, 504);
            this.lvAuthors.TabIndex = 2;
            this.lvAuthors.UseCompatibleStateImageBehavior = false;
            this.lvAuthors.View = System.Windows.Forms.View.Details;
            // 
            // colAuthorName
            // 
            this.colAuthorName.Text = "Автор";
            this.colAuthorName.Width = 400;
            // 
            // colAuthorCount
            // 
            this.colAuthorCount.Text = "Заказов";
            this.colAuthorCount.Width = 180;
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.btnBooks);
            this.tabBooks.Controls.Add(this.lvBooks);
            this.tabBooks.Location = new System.Drawing.Point(4, 34);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Padding = new System.Windows.Forms.Padding(6);
            this.tabBooks.Size = new System.Drawing.Size(976, 573);
            this.tabBooks.TabIndex = 3;
            this.tabBooks.Text = "Книги";
            this.tabBooks.UseVisualStyleBackColor = true;
            // 
            // btnBooks
            // 
            this.btnBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBooks.Location = new System.Drawing.Point(839, 6);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(125, 40);
            this.btnBooks.TabIndex = 3;
            this.btnBooks.Text = "Обновить";
            this.btnBooks.UseVisualStyleBackColor = true;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // lvBooks
            // 
            this.lvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                        | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBookName,
            this.colBookCount});
            this.lvBooks.FullRowSelect = true;
            this.lvBooks.HideSelection = false;
            this.lvBooks.Location = new System.Drawing.Point(10, 60);
            this.lvBooks.Name = "lvBooks";
            this.lvBooks.Size = new System.Drawing.Size(954, 504);
            this.lvBooks.TabIndex = 2;
            this.lvBooks.UseCompatibleStateImageBehavior = false;
            this.lvBooks.View = System.Windows.Forms.View.Details;
            // 
            // colBookName
            // 
            this.colBookName.Text = "Книга";
            this.colBookName.Width = 400;
            // 
            // colBookCount
            // 
            this.colBookCount.Text = "Заказов";
            this.colBookCount.Width = 180;
            // 
            // tabRequests
            // 
            this.tabRequests.Controls.Add(this.btnRequests);
            this.tabRequests.Controls.Add(this.cmbBuyer);
            this.tabRequests.Controls.Add(this.label3);
            this.tabRequests.Controls.Add(this.lvRequests);
            this.tabRequests.Location = new System.Drawing.Point(4, 34);
            this.tabRequests.Name = "tabRequests";
            this.tabRequests.Padding = new System.Windows.Forms.Padding(6);
            this.tabRequests.Size = new System.Drawing.Size(976, 573);
            this.tabRequests.TabIndex = 4;
            this.tabRequests.Text = "Заявки";
            this.tabRequests.UseVisualStyleBackColor = true;
            // 
            // btnRequests
            // 
            this.btnRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequests.Location = new System.Drawing.Point(839, 6);
            this.btnRequests.Name = "btnRequests";
            this.btnRequests.Size = new System.Drawing.Size(125, 40);
            this.btnRequests.TabIndex = 6;
            this.btnRequests.Text = "Обновить";
            this.btnRequests.UseVisualStyleBackColor = true;
            this.btnRequests.Click += new System.EventHandler(this.btnRequests_Click);
            // 
            // cmbBuyer
            // 
            this.cmbBuyer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuyer.FormattingEnabled = true;
            this.cmbBuyer.Location = new System.Drawing.Point(186, 10);
            this.cmbBuyer.Name = "cmbBuyer";
            this.cmbBuyer.Size = new System.Drawing.Size(329, 33);
            this.cmbBuyer.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Покупатель/все:";
            // 
            // lvRequests
            // 
            this.lvRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                        | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReqBuyer,
            this.colReqDate,
            this.colReqBook,
            this.colReqAmount,
            this.colReqStatus});
            this.lvRequests.FullRowSelect = true;
            this.lvRequests.HideSelection = false;
            this.lvRequests.Location = new System.Drawing.Point(10, 60);
            this.lvRequests.Name = "lvRequests";
            this.lvRequests.Size = new System.Drawing.Size(954, 504);
            this.lvRequests.TabIndex = 3;
            this.lvRequests.UseCompatibleStateImageBehavior = false;
            this.lvRequests.View = System.Windows.Forms.View.Details;
            // 
            // colReqBuyer
            // 
            this.colReqBuyer.Text = "Покупатель";
            this.colReqBuyer.Width = 220;
            // 
            // colReqDate
            // 
            this.colReqDate.Text = "Дата";
            this.colReqDate.Width = 120;
            // 
            // colReqBook
            // 
            this.colReqBook.Text = "Книга";
            this.colReqBook.Width = 240;
            // 
            // colReqAmount
            // 
            this.colReqAmount.Text = "Экз.";
            this.colReqAmount.Width = 80;
            // 
            // colReqStatus
            // 
            this.colReqStatus.Text = "Статус";
            this.colReqStatus.Width = 160;
            // 
            // tabRating
            // 
            this.tabRating.Controls.Add(this.btnRating);
            this.tabRating.Controls.Add(this.lvRating);
            this.tabRating.Location = new System.Drawing.Point(4, 34);
            this.tabRating.Name = "tabRating";
            this.tabRating.Padding = new System.Windows.Forms.Padding(6);
            this.tabRating.Size = new System.Drawing.Size(976, 573);
            this.tabRating.TabIndex = 5;
            this.tabRating.Text = "Рейтинг";
            this.tabRating.UseVisualStyleBackColor = true;
            // 
            // btnRating
            // 
            this.btnRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRating.Location = new System.Drawing.Point(839, 6);
            this.btnRating.Name = "btnRating";
            this.btnRating.Size = new System.Drawing.Size(125, 40);
            this.btnRating.TabIndex = 6;
            this.btnRating.Text = "Обновить";
            this.btnRating.UseVisualStyleBackColor = true;
            this.btnRating.Click += new System.EventHandler(this.btnRating_Click);
            // 
            // lvRating
            // 
            this.lvRating.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                        | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRating.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRatingType,
            this.colRatingName,
            this.colRatingScore});
            this.lvRating.FullRowSelect = true;
            this.lvRating.HideSelection = false;
            this.lvRating.Location = new System.Drawing.Point(10, 60);
            this.lvRating.Name = "lvRating";
            this.lvRating.Size = new System.Drawing.Size(954, 504);
            this.lvRating.TabIndex = 3;
            this.lvRating.UseCompatibleStateImageBehavior = false;
            this.lvRating.View = System.Windows.Forms.View.Details;
            // 
            // colRatingType
            // 
            this.colRatingType.Text = "Тип";
            this.colRatingType.Width = 120;
            // 
            // colRatingName
            // 
            this.colRatingName.Text = "Наименование";
            this.colRatingName.Width = 420;
            // 
            // colRatingScore
            // 
            this.colRatingScore.Text = "Сумма заказов";
            this.colRatingScore.Width = 180;
            // 
            // tabDelayed
            // 
            this.tabDelayed.Controls.Add(this.btnDelayed);
            this.tabDelayed.Controls.Add(this.cmbDelayedSupplier);
            this.tabDelayed.Controls.Add(this.label4);
            this.tabDelayed.Controls.Add(this.lvDelayed);
            this.tabDelayed.Location = new System.Drawing.Point(4, 34);
            this.tabDelayed.Name = "tabDelayed";
            this.tabDelayed.Padding = new System.Windows.Forms.Padding(6);
            this.tabDelayed.Size = new System.Drawing.Size(976, 573);
            this.tabDelayed.TabIndex = 6;
            this.tabDelayed.Text = "Задержки";
            this.tabDelayed.UseVisualStyleBackColor = true;
            // 
            // btnDelayed
            // 
            this.btnDelayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelayed.Location = new System.Drawing.Point(839, 6);
            this.btnDelayed.Name = "btnDelayed";
            this.btnDelayed.Size = new System.Drawing.Size(125, 40);
            this.btnDelayed.TabIndex = 9;
            this.btnDelayed.Text = "Обновить";
            this.btnDelayed.UseVisualStyleBackColor = true;
            this.btnDelayed.Click += new System.EventHandler(this.btnDelayed_Click);
            // 
            // cmbDelayedSupplier
            // 
            this.cmbDelayedSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDelayedSupplier.FormattingEnabled = true;
            this.cmbDelayedSupplier.Location = new System.Drawing.Point(196, 10);
            this.cmbDelayedSupplier.Name = "cmbDelayedSupplier";
            this.cmbDelayedSupplier.Size = new System.Drawing.Size(329, 33);
            this.cmbDelayedSupplier.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Поставщик/все:";
            // 
            // lvDelayed
            // 
            this.lvDelayed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                        | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDelayed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDelaySupplier,
            this.colDelayBook,
            this.colDelayDue,
            this.colDelayDays});
            this.lvDelayed.FullRowSelect = true;
            this.lvDelayed.HideSelection = false;
            this.lvDelayed.Location = new System.Drawing.Point(10, 60);
            this.lvDelayed.Name = "lvDelayed";
            this.lvDelayed.Size = new System.Drawing.Size(954, 504);
            this.lvDelayed.TabIndex = 6;
            this.lvDelayed.UseCompatibleStateImageBehavior = false;
            this.lvDelayed.View = System.Windows.Forms.View.Details;
            // 
            // colDelaySupplier
            // 
            this.colDelaySupplier.Text = "Поставщик";
            this.colDelaySupplier.Width = 240;
            // 
            // colDelayBook
            // 
            this.colDelayBook.Text = "Книга";
            this.colDelayBook.Width = 240;
            // 
            // colDelayDue
            // 
            this.colDelayDue.Text = "Срок поставки";
            this.colDelayDue.Width = 160;
            // 
            // colDelayDays
            // 
            this.colDelayDays.Text = "Дней задержки";
            this.colDelayDays.Width = 160;
            // 
            // tabCompleted
            // 
            this.tabCompleted.Controls.Add(this.btnCompleted);
            this.tabCompleted.Controls.Add(this.cmbCompletedBuyer);
            this.tabCompleted.Controls.Add(this.label5);
            this.tabCompleted.Controls.Add(this.lvCompleted);
            this.tabCompleted.Location = new System.Drawing.Point(4, 34);
            this.tabCompleted.Name = "tabCompleted";
            this.tabCompleted.Padding = new System.Windows.Forms.Padding(6);
            this.tabCompleted.Size = new System.Drawing.Size(976, 573);
            this.tabCompleted.TabIndex = 7;
            this.tabCompleted.Text = "Выполненные";
            this.tabCompleted.UseVisualStyleBackColor = true;
            // 
            // btnCompleted
            // 
            this.btnCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompleted.Location = new System.Drawing.Point(839, 6);
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.Size = new System.Drawing.Size(125, 40);
            this.btnCompleted.TabIndex = 9;
            this.btnCompleted.Text = "Обновить";
            this.btnCompleted.UseVisualStyleBackColor = true;
            this.btnCompleted.Click += new System.EventHandler(this.btnCompleted_Click);
            // 
            // cmbCompletedBuyer
            // 
            this.cmbCompletedBuyer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompletedBuyer.FormattingEnabled = true;
            this.cmbCompletedBuyer.Location = new System.Drawing.Point(186, 10);
            this.cmbCompletedBuyer.Name = "cmbCompletedBuyer";
            this.cmbCompletedBuyer.Size = new System.Drawing.Size(329, 33);
            this.cmbCompletedBuyer.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Покупатель/все:";
            // 
            // lvCompleted
            // 
            this.lvCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                        | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCompleted.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCompBuyer,
            this.colCompBook,
            this.colCompDate,
            this.colCompAmount});
            this.lvCompleted.FullRowSelect = true;
            this.lvCompleted.HideSelection = false;
            this.lvCompleted.Location = new System.Drawing.Point(10, 60);
            this.lvCompleted.Name = "lvCompleted";
            this.lvCompleted.Size = new System.Drawing.Size(954, 504);
            this.lvCompleted.TabIndex = 6;
            this.lvCompleted.UseCompatibleStateImageBehavior = false;
            this.lvCompleted.View = System.Windows.Forms.View.Details;
            // 
            // colCompBuyer
            // 
            this.colCompBuyer.Text = "Покупатель";
            this.colCompBuyer.Width = 240;
            // 
            // colCompBook
            // 
            this.colCompBook.Text = "Книга";
            this.colCompBook.Width = 240;
            // 
            // colCompDate
            // 
            this.colCompDate.Text = "Закрыта";
            this.colCompDate.Width = 140;
            // 
            // colCompAmount
            // 
            this.colCompAmount.Text = "Экз.";
            this.colCompAmount.Width = 80;
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.tabControl1);
            this.Name = "QueryForm";
            this.Text = "Запросы по книжному магазину";
            this.tabControl1.ResumeLayout(false);
            this.tabContracts.ResumeLayout(false);
            this.tabContracts.PerformLayout();
            this.tabPublishers.ResumeLayout(false);
            this.tabAuthors.ResumeLayout(false);
            this.tabBooks.ResumeLayout(false);
            this.tabRequests.ResumeLayout(false);
            this.tabRequests.PerformLayout();
            this.tabRating.ResumeLayout(false);
            this.tabDelayed.ResumeLayout(false);
            this.tabDelayed.PerformLayout();
            this.tabCompleted.ResumeLayout(false);
            this.tabCompleted.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabContracts;
        private System.Windows.Forms.CheckBox chkAllPeriod;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnContracts;
        private System.Windows.Forms.ListView lvContracts;
        private System.Windows.Forms.ColumnHeader colFirm;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.ColumnHeader colRange;
        private System.Windows.Forms.TabPage tabPublishers;
        private System.Windows.Forms.Button btnPublishers;
        private System.Windows.Forms.ListView lvPublishers;
        private System.Windows.Forms.ColumnHeader colPubName;
        private System.Windows.Forms.ColumnHeader colPubCount;
        private System.Windows.Forms.TabPage tabAuthors;
        private System.Windows.Forms.Button btnAuthors;
        private System.Windows.Forms.ListView lvAuthors;
        private System.Windows.Forms.ColumnHeader colAuthorName;
        private System.Windows.Forms.ColumnHeader colAuthorCount;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.ListView lvBooks;
        private System.Windows.Forms.ColumnHeader colBookName;
        private System.Windows.Forms.ColumnHeader colBookCount;
        private System.Windows.Forms.TabPage tabRequests;
        private System.Windows.Forms.Button btnRequests;
        private System.Windows.Forms.ComboBox cmbBuyer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvRequests;
        private System.Windows.Forms.ColumnHeader colReqBuyer;
        private System.Windows.Forms.ColumnHeader colReqDate;
        private System.Windows.Forms.ColumnHeader colReqBook;
        private System.Windows.Forms.ColumnHeader colReqAmount;
        private System.Windows.Forms.ColumnHeader colReqStatus;
        private System.Windows.Forms.TabPage tabRating;
        private System.Windows.Forms.Button btnRating;
        private System.Windows.Forms.ListView lvRating;
        private System.Windows.Forms.ColumnHeader colRatingType;
        private System.Windows.Forms.ColumnHeader colRatingName;
        private System.Windows.Forms.ColumnHeader colRatingScore;
        private System.Windows.Forms.TabPage tabDelayed;
        private System.Windows.Forms.Button btnDelayed;
        private System.Windows.Forms.ComboBox cmbDelayedSupplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvDelayed;
        private System.Windows.Forms.ColumnHeader colDelaySupplier;
        private System.Windows.Forms.ColumnHeader colDelayBook;
        private System.Windows.Forms.ColumnHeader colDelayDue;
        private System.Windows.Forms.ColumnHeader colDelayDays;
        private System.Windows.Forms.TabPage tabCompleted;
        private System.Windows.Forms.Button btnCompleted;
        private System.Windows.Forms.ComboBox cmbCompletedBuyer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvCompleted;
        private System.Windows.Forms.ColumnHeader colCompBuyer;
        private System.Windows.Forms.ColumnHeader colCompBook;
        private System.Windows.Forms.ColumnHeader colCompDate;
        private System.Windows.Forms.ColumnHeader colCompAmount;
    }
}
