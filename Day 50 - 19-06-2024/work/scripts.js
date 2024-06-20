let currentPage = 1;
let skip = 0;
const limit = 5;
let totalQuotes = 0;
let allQuotes = [];
let searchQuery = '';
let filteredQuotes = [];

function applySearchAndSort() {
    const sortBy = document.getElementById('sort-select').value;

    if (searchQuery) {
        filteredQuotes = allQuotes.filter(quote => quote.author.toLowerCase().includes(searchQuery));
    } else {
        filteredQuotes = [...allQuotes];
    }

    if (sortBy === 'asc') {
        filteredQuotes.sort((a, b) => a.author.localeCompare(b.author));
    } else if (sortBy === 'desc') {
        filteredQuotes.sort((a, b) => b.author.localeCompare(a.author));
    }
    currentPage = 1;
    skip = 0;
    displayQuotes(filteredQuotes.slice(skip, skip + limit));
    generatePaginationNumbers(Math.ceil(filteredQuotes.length / limit));
}


window.addEventListener("load", function () {
    loadAllQuotes();
    applySearchAndSort();

    document.getElementById('next').addEventListener('click', function () {
        if ((currentPage * limit) < filteredQuotes.length) {
            currentPage++;
            skip = (currentPage - 1) * limit;
            displayQuotes(filteredQuotes.slice(skip, skip + limit));
            generatePaginationNumbers(Math.ceil(filteredQuotes.length / limit));
        }
    });

    document.getElementById('prev').addEventListener('click', function () {
        if (currentPage > 1) {
            currentPage--;
            skip = (currentPage - 1) * limit;
            displayQuotes(filteredQuotes.slice(skip, skip + limit));
            generatePaginationNumbers(Math.ceil(filteredQuotes.length / limit));
        }
    });

    document.addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('page-link')) {
            event.preventDefault();
            const page = parseInt(event.target.dataset.page);
            if (!isNaN(page)) {
                currentPage = page;
                skip = (currentPage - 1) * limit;
                displayQuotes(filteredQuotes.slice(skip, skip + limit));
                generatePaginationNumbers(Math.ceil(filteredQuotes.length / limit));
            }
        }
    });

    document.getElementById('search-input').addEventListener('input', function (event) {
        searchQuery = event.target.value.toLowerCase();
        applySearchAndSort();
    });

    document.getElementById('sort-select').addEventListener('change', function () {
        applySearchAndSort();
    });

    // document.getElementById('search-input').addEventListener('input', function (event) {
    //     searchQuery = event.target.value.toLowerCase();
    //     currentPage = 1;
    //     skip = 0;
    //     if (searchQuery) {
    //         filteredQuotes = allQuotes.filter(quote => quote.author.toLowerCase().includes(searchQuery));
    //         displayQuotes(filteredQuotes.slice(0, limit));
    //         generatePaginationNumbers(Math.ceil(filteredQuotes.length / limit));
    //     } else {
    //         displayQuotes(allQuotes.slice(0, limit));
    //         generatePaginationNumbers(Math.ceil(totalQuotes / limit));
    //     }
    // });
});

function loadAllQuotes() {
    fetch(`https://dummyjson.com/quotes?limit=1454`)
        .then(response => response.json())
        .then(data => {
            allQuotes = data.quotes;
            totalQuotes = data.total;
            displayQuotes(allQuotes.slice(0, limit));
            generatePaginationNumbers(Math.ceil(totalQuotes / limit));
        });
}

function displayQuotes(quotes) {
    const quotesContainer = document.getElementById('quotes-container');
    quotesContainer.innerHTML = '';
    quotes.forEach(quote => {
        const quoteElement = document.createElement('div');
        quoteElement.classList.add('quote', 'card', 'mb-3');
        quoteElement.innerHTML = `
            <div class="card-body">
                <p class="card-text">${quote.quote}</p>
                <div class="blockquote-footer">${quote.author}</div>
            </div>
        `;
        quotesContainer.appendChild(quoteElement);
    });
}

function generatePaginationNumbers(totalPages) {
    const paginationNumbers = document.getElementById('pagination-numbers');
    paginationNumbers.innerHTML = '';

    const startPage = Math.max(1, currentPage - 2);
    const endPage = Math.min(totalPages, startPage + 5);

    if (currentPage > 1) {
        paginationNumbers.innerHTML += '<li class="page-item"><a class="page-link" href="#" data-page="1">First</a></li>';
    }

    for (let i = startPage; i <= endPage; i++) {
        const pageItem = document.createElement('li');
        pageItem.classList.add('page-item');
        if (i === currentPage) {
            pageItem.classList.add('active');
        }
        pageItem.innerHTML = `<a class="page-link" href="#" data-page="${i}">${i}</a>`;
        paginationNumbers.appendChild(pageItem);
    }

    if (currentPage < totalPages) {
        paginationNumbers.innerHTML += `<li class="page-item"><a class="page-link" href="#" data-page="${totalPages}">Last</a></li>`;
    }
}
