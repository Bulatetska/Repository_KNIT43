// Сценарій k6. Запуск через bench/windows/load.ps1 або вручну (див. README.md).
import http from 'k6/http';
import { check } from 'k6';

const paths = {
  ping: '/api/ping',
  items: '/api/items?category=books&minPrice=100&activeOnly=true',
  full: '/api/items',
  cpu: '/api/cpu',
};

export const options = {
  vus: Number(__ENV.VUS || 100),
  duration: __ENV.DURATION || '2m',
  summaryTrendStats: ['avg', 'p(50)', 'p(90)', 'p(95)', 'p(99)', 'max'],
};

export default function () {
  const r = http.get(`${__ENV.BASE}${paths[__ENV.EP || 'ping']}`);
  check(r, { 'status 200': (x) => x.status === 200 });
}
