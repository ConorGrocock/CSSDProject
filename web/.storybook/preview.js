import { ReactQueryDevtools } from 'react-query/devtools'
import {QueryClient, QueryClientProvider} from "react-query";

export const parameters = {
  actions: { argTypesRegex: "^on[A-Z].*" },
  controls: {
    matchers: {
      color: /(background|color)$/i,
      date: /Date$/,
    },
  },
}

const queryClient = new QueryClient()
export const decorators=[
  (story) => (
      <QueryClientProvider client={queryClient}>
        {story()}
        <ReactQueryDevtools />
      </QueryClientProvider>
  ),
]