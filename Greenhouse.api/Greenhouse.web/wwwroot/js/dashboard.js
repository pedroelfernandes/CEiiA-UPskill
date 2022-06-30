function updateAssetTypes() {
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

        myChart.config.type = 'pie';
        myChart.config.options.plugins.title.text = 'Asset Types';
        myChart.config.data.labels = assetTypeNames;
        myChart.config.data.datasets[0].data = assetTypeCount;
        myChart.config.data.datasets[0].backgroundColor = generateColor(datapoints.length);
        myChart.config.data.datasets[0].borderColor = 'rgb(255, 255, 255)';
        myChart.config.options.plugins.legend.position = 'top';
        myChart.update();
    });
};


function updateSensorTypes(assetId) {
    async function fetchData() {
        const url = 'https://localhost:7248/dashboard/getsensorscount?assetId=' + assetId;
        const response = await fetch(url);
        const datapoints = await response.json();
        return datapoints;
    };

    fetchData().then(datapoints => {
        const sensorTypeNames = datapoints.map(
            function (index) {
                return index.type;
            });

        const sensorTypeCount = datapoints.map(
            function (index) {
                return index.count;
            });

        myChart.config.type = 'pie';
        myChart.config.options.plugins.title.text = 'Sensor Types';
        myChart.config.data.labels = sensorTypeNames;
        myChart.config.data.datasets[0].data = sensorTypeCount;
        myChart.config.data.datasets[0].backgroundColor = generateColor(datapoints.length);
        myChart.config.data.datasets[0].borderColor = 'rgb(255, 255, 255)';
        myChart.config.options.plugins.legend.position = 'top';
        myChart.update();
    });
};


function updateSensor(sensorId, sensorName, sensorUnit) {
    async function fetchData() {
        const url = 'https://localhost:7248/dashboard/getsensorreadings?sensorId=' + sensorId;
        const response = await fetch(url);
        const datapoints = await response.json();
        return datapoints;
    };

    fetchData().then(datapoints => {
        const readingValue = datapoints.map(
            function (index) {
                return index.value;
            });

        const readingDate = datapoints.map(
            function (index) {
                return index.date;
            });

        myChart.config.type = 'line';
        myChart.config.options.plugins.title.text = sensorName;
        myChart.config.data.labels = readingDate;
        myChart.config.data.datasets[0].data = readingValue;
        myChart.config.data.datasets[0].label = 'Unit: ' + sensorUnit;
        myChart.config.data.datasets[0].backgroundColor = 'rgb(255, 255, 255)';
        myChart.config.data.datasets[0].borderColor = 'rgb(75, 192, 192)';
        myChart.config.options.plugins.legend.position = 'right';
        myChart.update();
    });
};


function updateSensorBetweenDates(sensorId, sensorName, sensorUnit, startDate, endDate) {
    async function fetchData() {
        const url = 'https://localhost:7248/dashboard/getsensorreadingsbetweendates?sensorId=' + sensorId + '&startdate=' + startDate + '&enddate=' + endDate;
        const response = await fetch(url);
        const datapoints = await response.json();
        return datapoints;
    };

    fetchData().then(datapoints => {
        const readingValue = datapoints.map(
            function (index) {
                return index.value;
            });

        const readingDate = datapoints.map(
            function (index) {
                return index.date;
            });

        myChart.config.type = 'line';
        myChart.config.options.plugins.title.text = sensorName;
        myChart.config.data.labels = readingDate;
        myChart.config.data.datasets[0].data = readingValue;
        myChart.config.data.datasets[0].label = 'Unit: ' + sensorUnit;
        myChart.config.data.datasets[0].backgroundColor = 'rgb(255, 255, 255)';
        myChart.config.data.datasets[0].borderColor = 'rgb(75, 192, 192)';
        myChart.config.options.plugins.legend.position = 'right';
        myChart.update();
    });
};


function generateColor(size) {
    let arr = [];
    for (let i = 0; i < size; i++) {
        arr[i] = '#' + Math.floor(Math.random() * 16777215).toString(16)
    }

    return arr;
    //let arr = [];
    //let r1 = '8';
    //let g1 = '2';
    //let b1 = '8';
    //for (let i = 0; i < size; i++) {
    //    arr[i] = '#' + r1 + Math.floor(Math.random() * 16) + g1 + Math.floor(Math.random() * 16) + b1 + Math.floor(Math.random() * 16);
    //}

    //return arr;
}

const data = {
    labels: [],
    datasets: [{}]
};

const config = {
    type: 'pie',
    data,
    options: {
        aspectRatio: 2,
        plugins: {
            title: {
                display: true,
                font: {
                    size: 32
                },
                color: 'black'
            },
            legend: {
                position: 'top'
            }
        }
    }
};

const myChart = new Chart(
    document.getElementById('myChart'),
    config
);