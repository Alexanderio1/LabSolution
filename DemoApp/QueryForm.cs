using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class QueryForm : Form
    {
        private readonly List<ContractInfo> _contracts;
        private readonly List<RequestItem> _requests;
        private readonly List<SupplyIssue> _delays;
        private readonly List<CompletedRequest> _done;

        public QueryForm()
        {
            InitializeComponent();

            _contracts = SeedContracts();
            _requests = SeedRequests();
            _delays = SeedDelays();
            _done = SeedCompleted();

            FillCombos();
            RenderContracts();
            RenderPublishers();
            RenderAuthors();
            RenderBooks();
            RenderRatings();
            RenderRequests();
            RenderDelays();
            RenderCompleted();
        }

        private void FillCombos()
        {
            cmbBuyer.Items.Clear();
            cmbBuyer.Items.Add("Все покупатели");
            foreach (string buyer in _requests.Select(r => r.Buyer).Distinct())
                cmbBuyer.Items.Add(buyer);
            cmbBuyer.SelectedIndex = 0;

            cmbDelayedSupplier.Items.Clear();
            cmbDelayedSupplier.Items.Add("Все поставщики");
            foreach (string supplier in _delays.Select(d => d.Supplier).Distinct())
                cmbDelayedSupplier.Items.Add(supplier);
            cmbDelayedSupplier.SelectedIndex = 0;

            cmbCompletedBuyer.Items.Clear();
            cmbCompletedBuyer.Items.Add("Все покупатели");
            foreach (string buyer in _done.Select(d => d.Buyer).Distinct())
                cmbCompletedBuyer.Items.Add(buyer);
            cmbCompletedBuyer.SelectedIndex = 0;
        }

        private void btnContracts_Click(object sender, EventArgs e) => RenderContracts();
        private void btnPublishers_Click(object sender, EventArgs e) => RenderPublishers();
        private void btnAuthors_Click(object sender, EventArgs e) => RenderAuthors();
        private void btnBooks_Click(object sender, EventArgs e) => RenderBooks();
        private void btnRating_Click(object sender, EventArgs e) => RenderRatings();
        private void btnRequests_Click(object sender, EventArgs e) => RenderRequests();
        private void btnDelayed_Click(object sender, EventArgs e) => RenderDelays();
        private void btnCompleted_Click(object sender, EventArgs e) => RenderCompleted();

        private void RenderContracts()
        {
            lvContracts.Items.Clear();

            IEnumerable<ContractInfo> data = _contracts;
            if (!chkAllPeriod.Checked)
            {
                DateTime from = dtFrom.Value.Date;
                DateTime to = dtTo.Value.Date;
                data = data.Where(c => c.ValidFrom.Date <= to && c.ValidTo.Date >= from);
            }

            var grouped = data
                .GroupBy(c => c.Firm)
                .Select(g => new
                {
                    Firm = g.Key,
                    Count = g.Count(),
                    Range = $"{g.Min(x => x.ValidFrom):d} — {g.Max(x => x.ValidTo):d}"
                })
                .OrderBy(g => g.Firm);

            foreach (var item in grouped)
            {
                var lvi = new ListViewItem(item.Firm);
                lvi.SubItems.Add(item.Count.ToString());
                lvi.SubItems.Add(item.Range);
                lvContracts.Items.Add(lvi);
            }
        }

        private void RenderPublishers()
        {
            lvPublishers.Items.Clear();
            var data = _requests
                .GroupBy(r => r.Publisher)
                .Select(g => new { Publisher = g.Key, Count = g.Sum(x => x.Amount) })
                .OrderByDescending(g => g.Count)
                .ThenBy(g => g.Publisher);

            foreach (var item in data)
            {
                var lvi = new ListViewItem(item.Publisher);
                lvi.SubItems.Add(item.Count.ToString());
                lvPublishers.Items.Add(lvi);
            }
        }

        private void RenderAuthors()
        {
            lvAuthors.Items.Clear();
            var data = _requests
                .GroupBy(r => r.Author)
                .Select(g => new { Author = g.Key, Count = g.Sum(x => x.Amount) })
                .OrderByDescending(g => g.Count)
                .ThenBy(g => g.Author);

            foreach (var item in data)
            {
                var lvi = new ListViewItem(item.Author);
                lvi.SubItems.Add(item.Count.ToString());
                lvAuthors.Items.Add(lvi);
            }
        }

        private void RenderBooks()
        {
            lvBooks.Items.Clear();
            var data = _requests
                .GroupBy(r => r.Book)
                .Select(g => new { Book = g.Key, Count = g.Sum(x => x.Amount) })
                .OrderByDescending(g => g.Count)
                .ThenBy(g => g.Book);

            foreach (var item in data)
            {
                var lvi = new ListViewItem(item.Book);
                lvi.SubItems.Add(item.Count.ToString());
                lvBooks.Items.Add(lvi);
            }
        }

        private void RenderRatings()
        {
            lvRating.Items.Clear();

            var books = _requests.GroupBy(r => r.Book)
                                  .Select(g => new RatingItem("Книга", g.Key, g.Sum(x => x.Amount)));
            var authors = _requests.GroupBy(r => r.Author)
                                    .Select(g => new RatingItem("Автор", g.Key, g.Sum(x => x.Amount)));
            var combined = books.Concat(authors)
                                .OrderByDescending(r => r.Score)
                                .ThenBy(r => r.Name)
                                .Take(10);

            foreach (var r in combined)
            {
                var lvi = new ListViewItem(r.Type);
                lvi.SubItems.Add(r.Name);
                lvi.SubItems.Add(r.Score.ToString());
                lvRating.Items.Add(lvi);
            }
        }

        private void RenderRequests()
        {
            lvRequests.Items.Clear();
            string selectedBuyer = cmbBuyer.SelectedItem?.ToString();
            var data = _requests.AsEnumerable();
            if (!string.IsNullOrEmpty(selectedBuyer) && selectedBuyer != "Все покупатели")
                data = data.Where(r => r.Buyer == selectedBuyer);

            foreach (var r in data.OrderByDescending(r => r.RequestDate))
            {
                var lvi = new ListViewItem(r.Buyer);
                lvi.SubItems.Add(r.RequestDate.ToShortDateString());
                lvi.SubItems.Add(r.Book);
                lvi.SubItems.Add(r.Amount.ToString());
                lvi.SubItems.Add(r.Status);
                lvRequests.Items.Add(lvi);
            }
        }

        private void RenderDelays()
        {
            lvDelayed.Items.Clear();
            string selectedSupplier = cmbDelayedSupplier.SelectedItem?.ToString();
            var data = _delays.AsEnumerable();
            if (!string.IsNullOrEmpty(selectedSupplier) && selectedSupplier != "Все поставщики")
                data = data.Where(d => d.Supplier == selectedSupplier);

            foreach (var d in data.OrderBy(d => d.DueDate))
            {
                var lvi = new ListViewItem(d.Supplier);
                lvi.SubItems.Add(d.Book);
                lvi.SubItems.Add(d.DueDate.ToShortDateString());
                lvi.SubItems.Add(d.DaysDelayed.ToString());
                lvDelayed.Items.Add(lvi);
            }
        }

        private void RenderCompleted()
        {
            lvCompleted.Items.Clear();
            string selectedBuyer = cmbCompletedBuyer.SelectedItem?.ToString();
            var data = _done.AsEnumerable();
            if (!string.IsNullOrEmpty(selectedBuyer) && selectedBuyer != "Все покупатели")
                data = data.Where(d => d.Buyer == selectedBuyer);

            foreach (var d in data.OrderByDescending(d => d.ClosedOn))
            {
                var lvi = new ListViewItem(d.Buyer);
                lvi.SubItems.Add(d.Book);
                lvi.SubItems.Add(d.ClosedOn.ToShortDateString());
                lvi.SubItems.Add(d.Amount.ToString());
                lvCompleted.Items.Add(lvi);
            }
        }

        #region Sample data

        private static List<ContractInfo> SeedContracts() => new List<ContractInfo>
        {
            new ContractInfo("Издательство Север", new DateTime(2020, 1, 1), new DateTime(2020, 12, 31)),
            new ContractInfo("Городские книги", new DateTime(2021, 2, 15), new DateTime(2022, 2, 15)),
            new ContractInfo("Лабиринт", new DateTime(2022, 6, 1), new DateTime(2023, 5, 31)),
            new ContractInfo("Городские книги", new DateTime(2023, 3, 1), new DateTime(2024, 3, 1)),
            new ContractInfo("Издательство Север", new DateTime(2024, 1, 1), new DateTime(2024, 12, 31)),
        };

        private static List<RequestItem> SeedRequests() => new List<RequestItem>
        {
            new RequestItem("ООО 'Клен'", "Чехов", "Палата №6", "Издательство Север", 12, new DateTime(2024, 3, 12), "Выполнена"),
            new RequestItem("ООО 'Клен'", "Булгаков", "Мастер и Маргарита", "Городские книги", 8, new DateTime(2024, 4, 2), "В работе"),
            new RequestItem("Магазин 'Рассвет'", "Пушкин", "Евгений Онегин", "Лабиринт", 15, new DateTime(2024, 1, 28), "Выполнена"),
            new RequestItem("Магазин 'Рассвет'", "Булгаков", "Собачье сердце", "Городские книги", 20, new DateTime(2024, 4, 15), "Задержана"),
            new RequestItem("ООО 'Клен'", "Чехов", "Дуэль", "Издательство Север", 5, new DateTime(2024, 2, 3), "Выполнена"),
            new RequestItem("Книжный дом", "Толстой", "Война и мир", "Городские книги", 7, new DateTime(2024, 5, 1), "В работе"),
            new RequestItem("Книжный дом", "Булгаков", "Белая гвардия", "Городские книги", 9, new DateTime(2024, 5, 18), "Задержана"),
        };

        private static List<SupplyIssue> SeedDelays() => new List<SupplyIssue>
        {
            new SupplyIssue("Лабиринт", "Евгений Онегин", new DateTime(2024, 4, 5), 6),
            new SupplyIssue("Городские книги", "Белая гвардия", new DateTime(2024, 5, 20), 10),
            new SupplyIssue("Городские книги", "Мастер и Маргарита", new DateTime(2024, 4, 25), 4),
        };

        private static List<CompletedRequest> SeedCompleted() => new List<CompletedRequest>
        {
            new CompletedRequest("ООО 'Клен'", "Палата №6", 12, new DateTime(2024, 3, 15)),
            new CompletedRequest("ООО 'Клен'", "Дуэль", 5, new DateTime(2024, 2, 5)),
            new CompletedRequest("Магазин 'Рассвет'", "Евгений Онегин", 15, new DateTime(2024, 2, 10)),
        };

        #endregion

        #region DTOs

        private class ContractInfo
        {
            public string Firm { get; }
            public DateTime ValidFrom { get; }
            public DateTime ValidTo { get; }

            public ContractInfo(string firm, DateTime validFrom, DateTime validTo)
            {
                Firm = firm;
                ValidFrom = validFrom;
                ValidTo = validTo;
            }
        }

        private class RequestItem
        {
            public string Buyer { get; }
            public string Author { get; }
            public string Book { get; }
            public string Publisher { get; }
            public int Amount { get; }
            public DateTime RequestDate { get; }
            public string Status { get; }

            public RequestItem(string buyer, string author, string book, string publisher,
                               int amount, DateTime requestDate, string status)
            {
                Buyer = buyer;
                Author = author;
                Book = book;
                Publisher = publisher;
                Amount = amount;
                RequestDate = requestDate;
                Status = status;
            }
        }

        private class SupplyIssue
        {
            public string Supplier { get; }
            public string Book { get; }
            public DateTime DueDate { get; }
            public int DaysDelayed { get; }

            public SupplyIssue(string supplier, string book, DateTime dueDate, int daysDelayed)
            {
                Supplier = supplier;
                Book = book;
                DueDate = dueDate;
                DaysDelayed = daysDelayed;
            }
        }

        private class CompletedRequest
        {
            public string Buyer { get; }
            public string Book { get; }
            public int Amount { get; }
            public DateTime ClosedOn { get; }

            public CompletedRequest(string buyer, string book, int amount, DateTime closedOn)
            {
                Buyer = buyer;
                Book = book;
                Amount = amount;
                ClosedOn = closedOn;
            }
        }

        private class RatingItem
        {
            public string Type { get; }
            public string Name { get; }
            public int Score { get; }

            public RatingItem(string type, string name, int score)
            {
                Type = type;
                Name = name;
                Score = score;
            }
        }

        #endregion
    }
}
