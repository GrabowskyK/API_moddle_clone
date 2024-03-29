import { createFileRoute, Outlet, redirect } from '@tanstack/react-router'

import { useAuth } from '@/lib/store/auth'

export const Route = createFileRoute('/_protected')({
  // beforeLoad: async ({ location }) => {
  // if (!useAuth.getState().isAuthenticated) {
  //   throw redirect({
  //     to: '/auth/sign-in',
  //     search: {
  //       // Use the current location to power a redirect after login
  //       // (Do not use `router.state.resolvedLocation` as it can
  //       // potentially lag behind the actual current location)
  //       redirect: location.href,
  //     },
  //   })
  // }
  // },
  component: Outlet,
})
