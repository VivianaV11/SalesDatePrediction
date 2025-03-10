const input = document.getElementById('sourceData');
const button = document.getElementById('updateData');
const chart = document.getElementById('chart');
const errorMessage = document.getElementById('errorMessage');

const width = 600;
const height = 240;
const colors = ['#e80560', '#FF4500', '#3ed44d', '#FF00FF', '#ffc803'];

function handleUpdateData() {
  const inputData = input.value.trim();

  const data = inputData.split(',').map(d => parseInt(d.trim())).filter(d => !isNaN(d));

  const validationError = validateInput(data);
  if (validationError) {
    errorMessage.textContent = validationError;
    return;
  } else {
    errorMessage.textContent = '';
  }

  createBarChart(data);
};

function validateInput(data) {
  if (data.length === 0) {
    return 'Please enter at least one number.';
  }
  if (data.some(d => d <= 0)) {
    return 'All numbers must be greater than 0.';
  }
  if (data.some(d => d > 100)) {
    return 'Numbers must be less than 100.';
  }
  if (new Set(data).size !== data.length) {
    return 'Duplicate numbers are not allowed.';
  }
  if (data.length > 15) {
    return 'The maximum allowed is 15 numbers.';
  }
  return null;
}


function createBarChart(data) {
  chart.innerHTML = '';
  const barHeight = height / data.length;

  const svg = d3.select('#chart')
    .append('svg')
    .attr('width', width)
    .attr('height', height);

  const xScale = d3.scaleLinear()
    .domain([0, d3.max(data)])
    .range([0, width]);

  svg.selectAll('rect')
    .data(data)
    .enter()
    .append('rect')
    .attr('x', 0)
    .attr('y', (d, i) => i * barHeight)
    .attr('width', d => xScale(d))
    .attr('height', barHeight - 5)
    .attr('fill', (d, i) => colors[i % colors.length])
    .attr('class', 'bar');

  svg.selectAll('text')
    .data(data)
    .enter()
    .append('text')
    .text(d => d)
    .attr('x', d => xScale(d) - 30)
    .attr('y', (d, i) => i * barHeight + (barHeight / 2))
    .attr('fill', '#fff')
    .style('font-size', '12px')
    .style('font-family', 'Arial')
    .attr('dy', '.35em');
}
