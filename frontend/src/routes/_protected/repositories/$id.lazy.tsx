import { createLazyFileRoute } from '@tanstack/react-router'

export const Route = createLazyFileRoute('/_protected/repositories/$id')({
  component: () => <div>Hello /_protected/repositories/$id!</div>
})