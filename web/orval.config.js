module.exports = {
  'api': {
    input: './swagger.json',
    output: {
      mode: "tags-split",
      target: 'src/api/',
      client: 'react-query',
      mock: false,
    },
  },
};