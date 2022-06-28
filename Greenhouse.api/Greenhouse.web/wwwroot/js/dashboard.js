function updateChart() {
    async function fetchData() {
        const url = 'https://localhost:7248/dashboard/getassetscount';
        const response = await fetch(url);
        const datapoints = await response.json();
        return datapoints;
    };

    fetchData().then(datapoints => {
        const assetTypeNames = datapoints.map(
            function (index) {
                return index.type;
            });

        const assetTypeCount = datapoints.map(
            function (index) {
                return index.count;
            });

        myChart.config.data.labels = assetTypeNames;
        myChart.config.data.datasets[0].data = assetTypeCount;
        myChart.config.data.datasets[0].backgroundColor = generateColor(datapoints.length);
        myChart.update();
    });
};

function generateColor(size) {
    let arr = [];
    for (let i = 0; i < size; i++) {
        arr[i] = '#' + Math.floor(Math.random() * 16777215).toString(16)
    }
    return arr;
}

const data = {
    labels: [],
    datasets: [{}]
};

const config = {
    type: 'pie',
    data,
    options: {
        plugins: {
            title: {
                display: true,
                text: 'Asset Types',
                font: {
                    size: 32
                },
                color: 'black'
            }
        }
    }
};

const myChart = new Chart(
    document.getElementById('myChart'),
    config
);