let popupChartInstance;

function loadPopupChart(sensorId) {
    fetch(`/Home/GetAqiHistory?sensorId=${sensorId}`)
        .then(res => res.json())
        .then(data => {
            const ctx = document.getElementById('popupChart').getContext('2d');
            if (popupChartInstance) popupChartInstance.destroy();

            popupChartInstance = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: data.dates,
                    datasets: [{
                        label: 'AQI (24h)',
                        data: data.aqiValues,
                        borderColor: 'rgba(255, 99, 132, 1)',
                        backgroundColor: 'rgba(255, 99, 132, 0.2)',
                        fill: true
                    }]
                },
                options: { responsive: true }
            });

            document.getElementById('popupChartContainer').style.display = 'block';
        });
}
